using BunnyBudgetter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services.Contracts
{
    public interface IPaymentService
    {
        Task AddPayment(Payment payment, Account account);

        Task AddPayment(Payment payment, int accountId);

        Task<Payment> BuildPayment(int? paymentTypeId, float amount, bool isIncome, string description);

        Task<PaymentType> BuildPaymentType(string name, float maxAmount);

        Task AddPaymentType(PaymentType paymentType, int accountId);
    }
}
