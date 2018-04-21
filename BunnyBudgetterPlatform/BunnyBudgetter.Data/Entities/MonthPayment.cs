using System.Collections.Generic;

namespace BunnyBudgetter.Data.Entities
{
    public class MonthPayment
    {
        public int Id { get; set; }
        public string MonthName { get; set; }
        public List<Payment> Payments { get; set; }
        public bool IsCurrentMonth { get; set; }
    }
}