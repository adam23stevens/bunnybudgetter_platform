using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services
{
    public interface IAccountService
    {
        IEnumerable<UserAccountDto> GetUserAccountDtos(int userId);

        Task AddPayment(Payment payment, Account account);

        Task AddAccount(Account account);
    }
}
