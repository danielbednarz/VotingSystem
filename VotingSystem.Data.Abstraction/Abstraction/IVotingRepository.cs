using VotingSystem.Domain;

namespace VotingSystem.Data.Abstraction
{
    public interface IVotingRepository : IRepository<Voting>
    {
        public Task<bool> IsVoterAlreadyVoted(int voterId);
        public Task<int> GetCandidateVotingCount(int candidateId);
    }
}
