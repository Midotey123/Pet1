using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Catalog : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
    }
}
