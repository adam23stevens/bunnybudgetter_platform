using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BunnyBudgetter.Business.Extensions;
using BunnyBudgetter.Business.Services.Contracts;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Enums;
using BunnyBudgetter.Data.Model;
using BunnyBudgetter.Data.Repositories;
using BunnyBudgetterPlatform.RequestModels;

namespace BunnyBudgetter.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;
        private readonly IPaymentService _paymentService;

        public AccountService(IRepository repository, IPaymentService paymentService)
        {
            _repository = repository;
            _paymentService = paymentService;
        }

        public async Task AddAccount(AccountCreationReq accountReq)
        {
            var account = new Account
            {
                AccountName = accountReq.Name,
                OverdraftLimit = accountReq.OverdraftLimit,
                SalaryScheduleType = ((SalaryScheduleType)accountReq.SalaryScheduleType),
                SalaryDayPaid = accountReq.SalaryDayPaid,
                MonthlyNetSalaryAmount = accountReq.MonthlyNetSalaryAmount
            };
            try
            {
                ConfigureNextPayDate(account, accountReq.LastDateSalaryPaid);
            }
            catch(Exception ex)
            {
                throw new Exception("Error with calculating salary dates - " + ex.Message);
            }

            var basePayment = new Payment
            {
                Date = DateTime.Now,
                Description = "Initial Funds",
                Amount = accountReq.CurrentAmount,
                IsIncome = true
            };

            var monthPayment = new MonthPayment
            {
                IsCurrentMonth = true,
                Month = DateTime.Today.Month,
                MonthPayDay = accountReq.LastDateSalaryPaid,
                Payments = new List<Payment>
                {
                    basePayment
                }
            };
            account.MonthPayments = new List<MonthPayment>
            {
                monthPayment
            };

            await _repository.AddEntity(account);

            var AccountUser = new AccountUser
            {
                AccountId = account.Id,
                UserId = accountReq.UserId
            };

            await _repository.UpdateEntity(AccountUser);

            var id = account.Id;
        }

        private void ConfigureNextPayDate(Account account, DateTime lastDateSalaryPaid)
        {
            var nextPayDate = new DateTime();
            switch (account.SalaryScheduleType)
            {
                case SalaryScheduleType.DayOfMonth:
                    //Take month of last paid, add one. append SalaryDayPaid as the day paid for new date. if this is saturday or sunday, make it a friday.
                    nextPayDate = lastDateSalaryPaid.AddMonths(1);
                    nextPayDate = new DateTime(nextPayDate.Year, nextPayDate.Month, account.SalaryDayPaid);
                    break;
                case SalaryScheduleType.EndOfMonth:
                    //Take month of last time paid and add one month. get the final day
                    nextPayDate = lastDateSalaryPaid.AddMonths(1);
                    var endOfMonthDay = DateTime.DaysInMonth(nextPayDate.Year, nextPayDate.Month);
                    nextPayDate = new DateTime(nextPayDate.Year, nextPayDate.Month, endOfMonthDay);
                    break;
                case SalaryScheduleType.LastWeekDayOfMonth:
                    //Take month of last time paid and one month. Get last day. remove days till they equal the day
                    nextPayDate = lastDateSalaryPaid.AddMonths(1);
                    var endDay = DateTime.DaysInMonth(nextPayDate.Year, nextPayDate.Month);
                    var dayOfWeek = ((DayOfWeek)account.SalaryDayPaid);
                    nextPayDate = new DateTime(nextPayDate.Year, nextPayDate.Month, endDay);
                    while (!nextPayDate.DayOfWeek.Equals(dayOfWeek))
                    {
                        nextPayDate = nextPayDate.AddDays(-1);
                    }
                    break;
                default:
                    break;
            }

            SetToWorkingDay(nextPayDate);

            if (nextPayDate < DateTime.Now)
            {
                throw new Exception();
            }
            else
            {
                account.NextDateSalaryPaid = nextPayDate;
            }
        }

        private void SetToWorkingDay(DateTime nextPayDate)
        {
            while(nextPayDate.DayOfWeek.Equals(DayOfWeek.Saturday) || nextPayDate.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                nextPayDate.AddDays(-1);
            }
        }

        public IEnumerable<UserAccountDto> GetUserAccountDtos(int userId)
        {
            var userAccounts = new List<UserAccountDto>();

            var accUser = _repository.GetAllWhere<AccountUser>(au => au.UserId == userId);

            var accountIds = accUser.Select(au => au.AccountId).ToList();

            var accountsDb = new List<Account>();

            foreach (var accountId in accountIds)
            {
                var accounts = _repository.GetAllWithIncludes<Account>(
                    inc => inc.MonthPayments
                    , includes => includes.PaymentTypes
                    , includes => includes.PlannedPayments
                    , includes => includes.AccountUsers);

                var account = accounts.FirstOrDefault(a => a.Id == accountId);

                if (account != null) accountsDb.Add(account);
            }

            if (accountsDb == null) return userAccounts;

            foreach (var acc in accountsDb)
            {
                var currMonthId = acc.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth).Id;

                var currMonth = _repository.GetAllWithIncludes<MonthPayment>(includes => includes.Payments).FirstOrDefault(m => m.Id == currMonthId);

                if (currMonth != null)
                {
                    currMonth.Payments = GenerateMonthPayments(currMonth, acc.PlannedPayments, acc.NextDateSalaryPaid) as ICollection<Payment>;
                }
                if (acc.NextDateSalaryPaid <= DateTime.Today)
                {
                    var newMonth = new MonthPayment();
                    do
                    {
                        var thisMonth = acc.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth);
                        var prevMonthAmount = acc.MonthPayments.Where(m => !m.IsCurrentMonth).OrderBy(m => m.Id).FirstOrDefault()?.EndOfMonthAmount ?? 0;
                        var totalPaymentsThisMonth = currMonth.Payments.Where(p => !p.IsIncome).Sum(p => p.Amount);
                        var totalIncomeThisMonth = currMonth.Payments.Where(p => p.IsIncome).Sum(p => p.Amount);
                        var endOfMonthAmount = prevMonthAmount + acc.MonthlyNetSalaryAmount + totalIncomeThisMonth - totalPaymentsThisMonth;
                        thisMonth.EndOfMonthAmount = endOfMonthAmount;
                        thisMonth.IsCurrentMonth = false;

                        newMonth = BuildNewMonth(acc);
                    }
                    while (newMonth.MonthPayDay <= DateTime.Today);
                }

                var dto = acc.ToUserAccountDto();
                dto.UserId = userId;

                userAccounts.Add(dto);
            }
            
            return userAccounts;
        }

        private MonthPayment BuildNewMonth(Account acc)
        {
            var newMonthPayment = new MonthPayment();
            var lastMonth = acc.MonthPayments.OrderBy(m => m.Id).FirstOrDefault();
            if (lastMonth != null)
            {
                newMonthPayment.IsCurrentMonth = true;
                newMonthPayment.Month = lastMonth.Month == 11 ? 0 : lastMonth.Month + 1; //redo this properly! 
                newMonthPayment.MonthPayDay = acc.NextDateSalaryPaid;
                ConfigureNextPayDate(acc, lastMonth.MonthPayDay);

                newMonthPayment.Payments = GenerateMonthPayments(newMonthPayment, acc.PlannedPayments, acc.NextDateSalaryPaid) as ICollection<Payment>;
            }

            //else build the initial month?
            return newMonthPayment;
        }

        private IEnumerable<Payment> GenerateMonthPayments(MonthPayment currentMonthPayment, ICollection<PlannedPayment> plannedPayments, DateTime nextPayDay)
        {
            var wasPaidOn = currentMonthPayment.MonthPayDay;
            var retPlannedPayments = new List<PlannedPayment>();

            foreach(var p in plannedPayments.ToList())
            {
                if (p.IsActive)
                {
                    var lastPayDay = currentMonthPayment.MonthPayDay;

                    var DateToPay = new DateTime(lastPayDay.Year, lastPayDay.Month, p.DayOfMonth);
                    if (DateToPay < lastPayDay)
                    {
                        DateToPay = new DateTime(lastPayDay.Year, currentMonthPayment.Month, p.DayOfMonth);
                    }

                    if (DateToPay >= wasPaidOn && DateToPay < nextPayDay)
                    {
                        retPlannedPayments.Add(p);

                        if (!currentMonthPayment.Payments.Any(payment => payment.PlannedPaymentId == p.Id && payment.Date == DateToPay))
                        {
                            var payment = new Payment
                            {
                                Amount = p.Amount,
                                Date = DateToPay,
                                Description = $"Planned Payment ({p.Name})",
                                PlannedPaymentId = p.Id
                            };

                            currentMonthPayment.Payments.Add(payment);
                        }
                    }
                }
            }

            _repository.UpdateEntity(currentMonthPayment);
            return currentMonthPayment.Payments;
        }
    }
}
