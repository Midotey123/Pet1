﻿using Application.Interfaces;
using Domain.Models;
using Infrastructure.Services.Posgresql;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class StatisticRep : Rep<Statistic>, IStatisticRep
    {
        private readonly AppDbContext context;
        public StatisticRep(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Statistic> GetByIdWithAll(int id)
        {
            return await context.Statistics
                .AsNoTracking()
                .Include(s => s.Habit)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task<IEnumerable<Statistic>> GetWithAll()
        {
            return await context.Statistics
                .AsNoTracking()
                .Include(s => s.Habit)
                .ToListAsync();
        }
    }
}
