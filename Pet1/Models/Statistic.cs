namespace Pet1.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public int TotalDays { get; set; }
        public int CompletedDays { get; set; }
        public bool IsDone { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
    }
}
