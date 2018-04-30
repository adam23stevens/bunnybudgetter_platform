using BunnyBudgetter.Business.Services.Contracts;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository _repository;

        public PaymentService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPayment(Payment payment, Account account)
        {
            var existingPayments = _repository.GetAllWithIncludes<MonthPayment>(m => m.Payments)
                                    .Where(m => m.IsCurrentMonth).FirstOrDefault()?.Payments;

            if (existingPayments == null)
            {
                account.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth).Payments = new List<Payment> { payment };
            }
            else
            {
                account.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth).Payments.Add(payment);
            }

            await _repository.UpdateEntityAsync(account);
        }

        public async Task AddPayment(Payment payment, int accountId)
        {
            var account = _repository.GetAllWithIncludes<Account>(a => a.MonthPayments)
                                      .Where(a => a.Id == accountId).FirstOrDefault();

            if (account == null) return;
            else

                await AddPayment(payment, account);
        }

        public async Task<PaymentType> BuildPaymentType(string name, float maxAmount)
        {
            var newPaymentType = new PaymentType
            {
                Name = name,
                MaxAmount = maxAmount
            };

            return await Task.FromResult(newPaymentType);
        }

        public async Task<Payment> BuildPayment(int? paymentTypeId, float amount, bool isIncome, string description)
        {
            var payment = new Payment
            {
                PaymentTypeId = paymentTypeId,
                Amount = amount,
                Date = DateTime.Today,
                IsIncome = isIncome,
                Description = description
            };

            return await Task.FromResult(payment);
        }

        public async Task AddPaymentType(PaymentType paymentType, int accountId)
        {
            paymentType.AccountId = accountId;

            await _repository.AddEntityAsync(paymentType);
        }
    }
}
