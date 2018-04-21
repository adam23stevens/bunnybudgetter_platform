namespace BunnyBudgetter.Data.Entities
{
    public class PlannedPayment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DayOfMonth { get; set; }
        public bool IsActive { get; set; }
    }
}