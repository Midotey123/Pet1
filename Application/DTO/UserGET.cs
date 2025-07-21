using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserGET
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
        public ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
    }
}
