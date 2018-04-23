using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunnyBudgetter.Data.Entities
{
    public class PlannedPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DayOfMonth { get; set; }
        public bool IsActive { get; set; }
        public float Amount { get; set; }
        //public ICollection<Payment> Payments { get; set; }
        public int AccountId { get; set; }
    }
}