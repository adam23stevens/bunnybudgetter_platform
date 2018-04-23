using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunnyBudgetter.Data.Entities
{
    public class PaymentType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float MaxAmount { get; set; }
        //public ICollection<Payment> Payments { get; set; }
        public int AccountId { get; set; }
        public bool IsPlannedPayment { get; set; }
    }
}