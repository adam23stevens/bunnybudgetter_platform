using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunnyBudgetter.Data.Entities
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? PlannedPaymentId { get; set; }
        public string Description { get; set; }
        public bool IsIncome { get; set; }
    }
}