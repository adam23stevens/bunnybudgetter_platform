using System;

namespace BunnyBudgetter.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int DayOfMonth { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Description { get; set; }
    }
}