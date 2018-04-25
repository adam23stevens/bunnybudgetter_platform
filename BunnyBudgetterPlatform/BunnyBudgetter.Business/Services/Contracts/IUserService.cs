using BunnyBudgetter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services.Contracts
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<string> GenerateNewAccessCode(int userId);
        User GetUserFromCode(string accessCode);
    }
}
