using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Business.Services.Contracts;
using BunnyBudgetterPlatform.RequestModels;

namespace BunnyBudgetterPlatform.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateUser(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("{userId}")]
        [Route("Code")]
        public async Task<IActionResult> GenerateAccessCode([FromBody] UserAccessCodeGenReq userAccessCodeReq)
        {
            if (userAccessCodeReq.userId > 0)
            {
                var newCode = await _userService.GenerateNewAccessCode(userAccessCodeReq.userId);
                return Ok(newCode);
            }

            return new BadRequestResult();
        }
    }
}