using Pet1.Data;
using Pet1.Interfaces;
using Pet1.Repositories;

namespace Pet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///TODO: отслеживатель привычек.
            

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped(typeof(IRep<>), typeof(Rep<>));
            builder.Services.AddScoped<IHabitRep, HabitRep>();
            builder.Services.AddScoped<IStatisticRep, StatisticRep>();


            var app = builder.Build();
            app.UseRouting();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();


            app.Run();
        }
    }
}
