using Microsoft.EntityFrameworkCore;
using VotingSystem.Application.Abstraction;
using VotingSystem.Application.Services;
using VotingSystem.Data.Abstraction;
using VotingSystem.Data.Repositories;
using VotingSystem.EntityFramework;
using VotingSystem.EntityFramework.Seed;

namespace VotingSystem.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IVoterRepository, VoterRepository>();
            builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
            builder.Services.AddScoped<IVotingRepository, VotingRepository>();
            builder.Services.AddScoped<IVotingService, VotingService>();

            builder.Services.AddControllers();

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


            app.MapControllers();

            app.Run();
        }
    }
}