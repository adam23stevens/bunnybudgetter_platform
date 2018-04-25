using BunnyBudgetter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyBudgetter.Data.Model
{
    public class UserAccountDto
    {
        public string AccountName { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public float RemainingBalance { get; set; }
        public List<Payment> CurrentMonthPayments { get; set; }
        public List<PaymentTypeDto> PaymentTypeDtos { get; set; }
    }
}
