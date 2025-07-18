using Domain.Services;

namespace Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
        public ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
    }
}
