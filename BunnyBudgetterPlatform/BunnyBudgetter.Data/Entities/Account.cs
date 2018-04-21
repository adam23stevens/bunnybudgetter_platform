using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyBudgetter.Data.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        List<User> AccountUsers { get; set; }
        List<MonthPayment> MonthPayments { get; set; }
        List<PlannedPayment> PlannedPayments {get;set;}
        List<PaymentType> PaymentTypes { get; set; }
    }
}
