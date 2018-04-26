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
    }
}
