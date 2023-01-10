using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> IsCandidateAlreadyExists(string name)
        {
            return await _context.Candidates.AnyAsync(x => x.Name == name);
        }
    }
}
