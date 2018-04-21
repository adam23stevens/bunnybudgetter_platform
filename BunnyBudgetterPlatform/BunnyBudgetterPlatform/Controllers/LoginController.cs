using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BunnyBudgetterPlatform.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BunnyBudgetterPlatform.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly BunnyBudgetterPlatformContext _context;

        public LoginController(BunnyBudgetterPlatformContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //private async Task Login(string username, string password)
        //{
            
        //}

    }
}