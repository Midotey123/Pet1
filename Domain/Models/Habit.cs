using Domain.Services;
using Domain.Validation;

namespace Domain.Models
{
    public class Habit : IEntity
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public bool GetUsedToId { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public Statistic? Statistic { get; private set; }
        public int? CatalogId { get; private set; }
        public Catalog? Catalog { get; private set; }
        public ICollection<Mark> Marks { get; private set; } = new List<Mark>();
        private Habit(string title, string? description, bool getUsedToIt, int userId, int? catalogId)
        {
            Title = title;
            GetUsedToId = getUsedToIt;
            UserId = userId;
            if (Description != null)
                Description = description;
            if (CatalogId != null)
                CatalogId = catalogId;
        }
        internal static Result<Habit> Create(string title, string? description, bool getUsedToIt, int userId, int? catalogId)
        {
            return Result<Habit>.Success(new Habit(title, description, getUsedToIt, userId, catalogId));
        }
        internal Result AddStatistic(Statistic statistic)
        {
            Statistic = statistic;
            return Result.Success();
        }
        internal Result Update(string? title, string? description, bool? getUsedToId, Catalog? catalog)
        {
            if (title != null)
                Title = title;
            if (description != null)
                Description = description;
            if (getUsedToId != null)
                GetUsedToId = (bool)getUsedToId;
            if (catalog != null)
                Catalog = catalog;
            return Result.Success();
        }
    }
}
