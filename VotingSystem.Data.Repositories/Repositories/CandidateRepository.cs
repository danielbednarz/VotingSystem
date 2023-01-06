using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;
using VotingSystem.EntityFramework;

namespace VotingSystem.Data.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(MainDatabaseContext context) : base(context)
        {
        }

    }
}
