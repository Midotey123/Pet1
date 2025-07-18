using Domain.Enums;
using Domain.Services;

namespace Domain.Models
{
    public class Statistic : IEntity
    {
        public int Id { get; set; }
        public int CompletedDays { get; set; }
        public int TotalDays { get; set; }
        public bool IsDone { get; set; }
        public PriorityEnum Priority { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
    }
}
