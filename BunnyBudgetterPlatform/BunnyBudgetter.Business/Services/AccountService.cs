using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BunnyBudgetter.Business.Extensions;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Model;
using BunnyBudgetter.Data.Repositories;

namespace BunnyBudgetter.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAccount(Account account)
        {
            await _repository.AddEntity(account);
        }

        public async Task AddPayment(Payment payment, Account account)
        {
            account.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth).Payments.Add(payment);

            await _repository.AddEntity(payment);

            await _repository.UpdateEntity(account);
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
                    currMonth.Payments = GenerateMonthPayments(currMonth, acc.PlannedPayments);
                }

                var dto = acc.ToUserAccountDto();
                dto.UserId = userId;

                userAccounts.Add(dto);
            }
            
            return userAccounts;
        }

        private ICollection<Payment> GenerateMonthPayments(MonthPayment currentMonthPayments, ICollection<PlannedPayment> plannedPayments)
        {
            var dayOfMonth = DateTime.Now.Day;

            var plannedPaymentsToPay = plannedPayments.Where(
                p => p.DayOfMonth <= dayOfMonth &&
                p.IsActive
                );
            
            plannedPaymentsToPay.ToList().ForEach(p =>
            {
                if (!currentMonthPayments.Payments.Any(payment => payment.PlannedPaymentId == p.Id))
                {
                    var payment = new Payment
                    {
                        Amount = p.Amount,
                        DayOfMonth = p.DayOfMonth,
                        Description = $"Planned Payment ({p.Name})",
                        PlannedPaymentId = p.Id
                    };

                    //_repository.AddEntity(payment);
                    currentMonthPayments.Payments.Add(payment);
                }
            });

            _repository.UpdateEntity(currentMonthPayments);
            return currentMonthPayments.Payments;
        }
    }
}
