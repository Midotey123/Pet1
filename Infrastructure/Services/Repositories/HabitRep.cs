using Application.Interfaces;
using Domain.Models;
using Infrastructure.Services.Posgresql;
using Infrastructure.Services.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services.Repositories
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
