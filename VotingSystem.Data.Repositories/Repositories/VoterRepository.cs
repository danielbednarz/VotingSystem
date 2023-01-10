using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> IsVoterAlreadyExists(string name)
        {
            return await _context.Voters.AnyAsync(x => x.Name == name);
        }

    }
}
