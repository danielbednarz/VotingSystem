using Microsoft.EntityFrameworkCore;
using VotingSystem.Application.Abstraction;
using VotingSystem.Application.Services;
using VotingSystem.Data.Abstraction;
using VotingSystem.Data.Repositories;
using VotingSystem.EntityFramework;
using VotingSystem.EntityFramework.Seed;
using VotingSystem.WebAPI.Core;

namespace VotingSystem.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            CoreBindings.Add(builder.Services);

            builder.Services.AddControllers();
            builder.Services.AddCors();

            builder.Services.AddDbContext<MainDatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MainDatabaseContext"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<MainDatabaseContext>();
                context.Database.Migrate();

                Seed.AddExampleData(context);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during migration");
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.MapControllers();

            app.Run();
        }
    }
}