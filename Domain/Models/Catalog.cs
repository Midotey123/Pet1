using Domain.Enums;
using Domain.Services;
using Domain.Validation;
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
        public CatalogTypeEnum Type { get; set; }
        public ICollection<Habit> Habits { get; set; } = new List<Habit>();
        private Catalog(string title, User creator, CatalogTypeEnum type)
        {
            Title = title;
            Creator = creator;
            Type = type;
        }
        internal static Result<Catalog> Create(string title, User creator, int catalogTypeId)
        {
            if (Enum.IsDefined(typeof(CatalogTypeEnum), catalogTypeId))
                return Result<Catalog>.Failure("Catalog type with that id not exists!");
            return Result<Catalog>.Success(new Catalog(title, creator, (CatalogTypeEnum)catalogTypeId));
        }
        internal Result AddHabit(Habit habit)
        {
            if (Habits.Contains(habit))
                return Result.Failure("Habit already in catalog!");
            Habits.Add(habit);
            return Result.Success();
        }
    }
}
