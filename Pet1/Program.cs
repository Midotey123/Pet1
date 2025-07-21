using Application.Interfaces;
using Application.Reps;
using Application.Services;
using Infrastructure.Database.Postgresql;
using Infrastructure.Database.Postgresql.Repositories;
using Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Pet1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///TODO: отслеживатель привычек.

            ///TODO: связать слои нормально.
            ///TODO: создать связи между моделями, репозитории их сделать и сервисы.

            ///TODO: решить траблы миграции.


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped(typeof(IRep<>), typeof(Rep<>));
            builder.Services.AddScoped<IHabitRep, HabitRep>();
            builder.Services.AddScoped<IStatisticRep, StatisticRep>();
            ///TODO: доделать аутентификацию и авторизацию.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
                {
                    o.Events = new JwtBearerEvents()
                });
            builder.Services.AddAuthorization();

            var app = builder.Build();
            app.UseRouting();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
