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
            var existingPayments = account.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth).Payments;
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
    }
}
