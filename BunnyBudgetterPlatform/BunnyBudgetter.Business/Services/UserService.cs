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
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(User user)
        {
            await _repository.AddEntity(user);
        }

        public async Task<string> GenerateNewAccessCode(int userId)
        {
            List<string> currentCodes = _repository.GetAll<User>().Select(u => u.AccessCode).ToList();
            var user = _repository.GetAllWhere<User>(u => u.Id == userId).FirstOrDefault();

            var _random = new Random();
            string newCode = "";
            do
            {
                newCode = _random.Next(0, 9999).ToString("D4");
            }
            while (currentCodes.Contains(newCode));

            if (user != null)
            {
                user.AccessCode = newCode;
                await _repository.UpdateEntity(user);
            }

            return newCode;
        }

        public User GetUserFromCode(string accessCode)
        {
            return _repository.GetAllWhere<User>(u => u.AccessCode == accessCode).FirstOrDefault();
        }
    }
}
