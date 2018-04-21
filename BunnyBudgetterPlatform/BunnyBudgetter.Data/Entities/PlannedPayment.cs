namespace BunnyBudgetter.Data.Entities
{
    public class PlannedPayment
    {
        public string Name { get; set; }
        public int DayOfMonth { get; set; }
        public bool IsActive { get; set; }
    }
}