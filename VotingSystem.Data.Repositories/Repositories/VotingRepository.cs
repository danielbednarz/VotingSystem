using Microsoft.EntityFrameworkCore;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;
using VotingSystem.EntityFramework;

namespace VotingSystem.Data.Repositories
{
    public class VotingRepository : Repository<Voting>, IVotingRepository
    {
        public VotingRepository(MainDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsVoterAlreadyVoted(int voterId)
        {
            return await _context.Votings.AnyAsync(x => x.VoterId == voterId);
        }

        public async Task<int> GetCandidateVotingCount(int candidateId)
        {
            return await _context.Votings.Where(x => x.CandidateId == candidateId).CountAsync();
        }
    }
}
