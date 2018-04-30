using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BunnyBudgetter.Data.Entities;
using BunnyBudgetterPlatform.Data.Model;
using BunnyBudgetter.Business.Services.Contracts;
using BunnyBudgetter.Comms.RequestModels;

namespace BunnyBudgetterPlatform.Controllers
{
    [Produces("application/json")]
    [Route("api/Payments")]
    public class PaymentsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IPaymentService _paymentService;

        public PaymentsController(IAccountService accountService, IPaymentService paymentService)
        {
            _accountService = accountService;
            _paymentService = paymentService;
        }

        //POST: api/Payments
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] PostPaymentReq req)
        {
            var newPayment = await _paymentService.BuildPayment(req.PaymentTypeId, req.Amount, req.IsIncome, req.Description);

            await _paymentService.AddPayment(newPayment, req.AccountId);

            return Ok();
        }

        //Post api/Payments
        [HttpPost]
        [Route("PaymentTypes")]
        public async Task<IActionResult> PostPaymentType([FromBody] PostPaymentTypeReq req)
        {
            var newPaymentType = await _paymentService.BuildPaymentType(req.Name, req.MaxAmount);

            await _paymentService.AddPaymentType(newPaymentType, req.AccountId);

            return Ok();
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment([FromRoute] int id, [FromBody] Payment payment)
        {
            return await Task.FromResult(Ok());
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            return await Task.FromResult(Ok());
        }
    }
}