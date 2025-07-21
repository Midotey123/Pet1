using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Infrastructure.Database.Postgresql
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration config;
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Mark> Marks { get; set; }
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
            modelBuilder.Entity<User>()  //user-habits
                .HasMany(u => u.Habits)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId)
                .IsRequired();
            modelBuilder.Entity<User>()  //user-catalogs
                .HasMany(u => u.Catalogs)
                .WithOne(c => c.Creator)
                .HasForeignKey(c => c.CreatorId)
                .IsRequired();
            modelBuilder.Entity<Habit>()  //habit-statistic
                .HasOne(h => h.Statistic)
                .WithOne(s => s.Habit)
                .HasForeignKey<Statistic>(s => s.HabitId)
                .IsRequired();
            modelBuilder.Entity<Habit>()  //habit-marks
                .HasMany(h => h.Marks)
                .WithOne(m => m.Habit)
                .HasForeignKey(m => m.HabitId)
                .IsRequired();
            modelBuilder.Entity<Catalog>()  //catalog-habits
                .HasMany(c => c.Habits)
                .WithOne(h => h.Catalog)
                .HasForeignKey(h => h.CatalogId)
                .IsRequired(); 

        }
    }

}

