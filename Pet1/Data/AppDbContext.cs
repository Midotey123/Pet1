using Microsoft.EntityFrameworkCore;
using Pet1.Models;

namespace Pet1.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration config;
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        //public DbSet<User> Users { get; set; }
        public AppDbContext(IConfiguration config)
        {
            this.config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(config.GetConnectionString("Postgresql"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Habits)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId)
                .IsRequired();
            modelBuilder.Entity<Habit>()
                .HasOne(h => h.Statistic)
                .WithOne(s => s.Habit)
                .HasForeignKey<Statistic>(s => s.HabitId)
                .IsRequired();


        }
    }
}
