using Domain.Services;
using Domain.Validation;
using Microsoft.VisualBasic;

namespace Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public ICollection<Habit> Habits { get; private set; } = new List<Habit>();
        public ICollection<Catalog> Catalogs { get; private set; } = new List<Catalog>();
        private User(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }
        internal static Result<User> Create(string username, string passwordHash)
        {
            return Result<User>.Success(new User(username, passwordHash));
        }
        internal Result AddHabit(Habit habit)
        {
            if (Habits.Contains(habit))
                return Result.Failure("User already have that habit!");
            Habits.Add(habit);
            return Result.Success();
        }
        internal Result AddCatalog(Catalog catalog)
        {
            if (Catalogs.Contains(catalog))
                return Result.Failure("User already have that catalog!");
            Catalogs.Add(catalog);
            return Result.Success();
        }
        internal Result Update(string newPasswordHash, string oldPasswordHash)
        {
            if (PasswordHash.ToLower() != oldPasswordHash.ToLower())
                return Result.Failure("Invalid password hash!");
            PasswordHash = newPasswordHash;
            return Result.Success();
        }
    }
}
