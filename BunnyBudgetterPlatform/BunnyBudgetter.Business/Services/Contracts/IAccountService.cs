using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Model;
using BunnyBudgetterPlatform.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services.Contracts
{
    public interface IAccountService
    {
        IEnumerable<UserAccountDto> GetUserAccountDtos(int userId);
        
        Task AddAccount(AccountCreationReq account);
    }
}
