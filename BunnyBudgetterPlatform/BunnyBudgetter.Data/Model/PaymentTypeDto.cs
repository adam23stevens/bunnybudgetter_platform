using BunnyBudgetter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyBudgetter.Data.Model
{
    public class PaymentTypeDto
    {
        public string Name { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public float RemainingAmountForMonth { get; set; }
        public float MaxAmount { get; set; }
    }
}
