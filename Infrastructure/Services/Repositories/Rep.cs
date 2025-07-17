using Application.Reps;
using Domain.Services;
using Infrastructure.Services.Posgresql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class Rep<T> : IRep<T>
        where T : class, IEntity
    {
        private readonly AppDbContext context;
        public Rep(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> Add(T item)
        {
            if (item == null)
                return false;
            await context.Set<T>().AddAsync(item);
            return true;
        }
        public async Task<bool> Update(T newItem)
        {
            if (newItem == null)
                return false;
            var oldItem = await GetById(newItem.Id);
            if (oldItem == null)
                return false;
            context.Set<T>().Update(newItem);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var item = await GetById(id);
            if (item == null)
                return false;
            context.Set<T>().Remove(item);
            return true;
        }
        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
