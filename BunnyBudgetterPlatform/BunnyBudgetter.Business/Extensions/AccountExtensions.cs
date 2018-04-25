using BunnyBudgetter.Data.Entities;
using BunnyBudgetter.Data.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BunnyBudgetter.Business.Extensions
{
    public static class AccountExtensions
    {
        public static UserAccountDto ToUserAccountDto(this Account account)
        {
            var month = account.MonthPayments.FirstOrDefault(m => m.IsCurrentMonth);
            var remainingBalance = account.MonthPayments.Where(m => !m.IsCurrentMonth).OrderBy(m => m.Id).FirstOrDefault()?.EndOfMonthAmount ?? 0;
            month.Payments.ToList().ForEach(p => remainingBalance = p.IsIncome ? remainingBalance + p.Amount : remainingBalance - p.Amount);

            var paymentTypeDtos = new List<PaymentTypeDto>();

            foreach(var paymentType in account.PaymentTypes)
            {
                paymentTypeDtos.Add(paymentType.ToPaymentTypeDto(month));    
            }

            return new UserAccountDto
            {
                AccountId = account.Id,
                AccountName = account.AccountName,
                PaymentTypeDtos = paymentTypeDtos,
                CurrentMonthPayments = month.Payments.ToList(),
                RemainingBalance = remainingBalance,
                Currentmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Month)
        };
        }
    }
}
