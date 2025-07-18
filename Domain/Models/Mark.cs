using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Mark : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
    }
}
