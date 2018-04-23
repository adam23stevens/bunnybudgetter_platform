using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyBudgetter.Business.Services
{
    public interface ILoginService
    {
        bool LoginUser(string username, string password);
    }
}
