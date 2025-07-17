using Application.Interfaces;
using Application.Reps;
using Application.Services;
using Infrastructure.Services.Posgresql;
using Infrastructure.Services.Repositories;

namespace Pet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///TODO: отслеживатель привычек.

            ///TODO: связать слои нормально.
            ///TODO: спроектировать бд, создать модели и связи между ними, репозитории их сделать и сервисы.


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped(typeof(IRep<>), typeof(Rep<>));
            builder.Services.AddScoped<IHabitRep, HabitRep>();
            builder.Services.AddScoped<IStatisticRep, StatisticRep>();
            builder.Services.AddScoped<ISimpleService, SimpleService>();


            var app = builder.Build();
            app.UseRouting();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();


            app.Run();
        }
    }
}
