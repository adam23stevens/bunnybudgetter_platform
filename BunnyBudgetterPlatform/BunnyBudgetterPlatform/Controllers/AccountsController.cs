using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetterPlatform.Data.Model;
using BunnyBudgetter.Business.Services;
using BunnyBudgetter.Data.Model;
using BunnyBudgetter.Business.Services.Contracts;
using BunnyBudgetterPlatform.RequestModels;

namespace BunnyBudgetterPlatform.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountsController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        // GET: api/Accounts
        [HttpGet("{userAccessCode}")]
        public IActionResult GetUserAccounts([FromRoute]string userAccessCode)
        {
            var user = _userService.GetUserFromCode(userAccessCode);
            if (user != null)
            {
                var userAccounts = _accountService.GetUserAccountDtos(user.Id);
                return Ok(userAccounts);
            }
            return new NotFoundResult();
        }

        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] AccountCreationReq accountCreationReq)
        {
            await _accountService.AddAccount(accountCreationReq);

            return Ok();
        }

        // GET: api/Accounts/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAccount([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var account = await _context.Accounts.SingleOrDefaultAsync(m => m.Id == id);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(account);
        //}

        // PUT: api/Accounts/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccount([FromRoute] int id, [FromBody] Account account)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != account.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(account).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Accounts
        //[HttpPost]
        //public async Task<IActionResult> PostAccount([FromBody] Account account)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Accounts.Add(account);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        //}

        //// DELETE: api/Accounts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var account = await _context.Accounts.SingleOrDefaultAsync(m => m.Id == id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Accounts.Remove(account);
        //    await _context.SaveChangesAsync();

        //    return Ok(account);
        //}

        //private bool AccountExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.Id == id);
        //}
    }
}