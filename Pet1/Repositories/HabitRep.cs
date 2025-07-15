using Microsoft.EntityFrameworkCore;
using Pet1.Data;
using Pet1.Interfaces;
using Pet1.Models;

namespace Pet1.Repositories
{
    public class HabitRep : Rep<Habit>, IHabitRep
    {
        private readonly AppDbContext context;
        public HabitRep(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Habit> GetByIdWithAll(int id)
        {
            return await context.Habits
                .AsNoTracking()
                .Include(h => h.User)
                .Include(h => h.Statistic)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task<IEnumerable<Habit>> GetWithAll()
        {
            return await context.Habits
                .AsNoTracking()
                .Include(h => h.User)
                .Include(h => h.Statistic)
                .ToListAsync();
        }
    }
}
