using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BunnyBudgetter.Data.Entities
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AccountName { get; set; }
        public ICollection<AccountUser> AccountUsers { get; set; }
        public ICollection<MonthPayment> MonthPayments { get; set; }
        public ICollection<PlannedPayment> PlannedPayments { get; set; }
        public ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
