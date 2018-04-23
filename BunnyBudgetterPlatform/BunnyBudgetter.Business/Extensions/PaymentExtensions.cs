using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BunnyBudgetter.Business.Extensions
{
    public static class PaymentExtensions
    {
        public static PaymentTypeDto ToPaymentTypeDto(this PaymentType paymentType, MonthPayment monthPayment)
        {
            var paymentTypeMonthPayments = monthPayment.Payments.Where(p => p.PaymentTypeId == paymentType.Id).ToList();

            var paymentTypeDto = new PaymentTypeDto
            {
                Name = paymentType.Name,
                Payments = paymentTypeMonthPayments
            };
            var amountSoFar = monthPayment.Payments.Where(p => p.PaymentTypeId == paymentType.Id)?.Sum(p => p.Amount);

            paymentTypeDto.RemainingAmountForMonth = paymentType.MaxAmount - amountSoFar ?? 0;

            return paymentTypeDto;
        }
    }
}
