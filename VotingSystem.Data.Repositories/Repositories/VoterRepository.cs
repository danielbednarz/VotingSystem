using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;
using VotingSystem.EntityFramework;

namespace VotingSystem.Data.Repositories
{
    public class VoterRepository : Repository<Voter>, IVoterRepository
    {
        public VoterRepository(MainDatabaseContext context) : base(context)
        {
        }

    }
}
