using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunnyBudgetter.Data.Entities
{
    public class MonthPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Month { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public bool IsCurrentMonth { get; set; }
        public int AccountId { get; set; }
        public float EndOfMonthAmount { get; set; }
        public DateTime MonthPayDay { get; set; }
    }
}