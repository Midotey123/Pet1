
using Application.Interfaces;
using Application.Services;
using Domain.Abstractions.Reps;
using Infrastructure.Services.Posgresql;
using Infrastructure.Services.Repositories;

namespace Pet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///TODO: отслеживатель привычек.

            ///TODO: связать слои.
            
            ///TODO: понять как сервисы доменные и репозитории инициалируются в program.
            ///TODO: понять как связаны infrastructure и application, нужно ли делать интерфейс в application, 
            ///и его тех.реализацию в infrastructure.

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
