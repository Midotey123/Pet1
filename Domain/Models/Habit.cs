using Domain.Services;

namespace Domain.Models
{
    public class Habit : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool GetUsedToId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Statistic? Statistic { get; set; }
    }
}
