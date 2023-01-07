using VotingSystem.Application.Abstraction;
using VotingSystem.Application.Services;
using VotingSystem.Data.Abstraction;
using VotingSystem.Data.Repositories;

namespace VotingSystem.WebAPI.Core
{
    public static class CoreBindings
    {
        public static IServiceCollection Add(IServiceCollection services)
        {
            AddServiceBindings(services);
            AddRepositoryBindings(services);

            return services;
        }

        private static IServiceCollection AddServiceBindings(IServiceCollection services)
        {
            services.AddScoped<IVoterService, VoterService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVotingService, VotingService>();

            return services;
        }

        private static IServiceCollection AddRepositoryBindings(IServiceCollection services)
        {
            services.AddScoped<IVoterRepository, VoterRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVotingRepository, VotingRepository>();

            return services;
        }
    }
}
