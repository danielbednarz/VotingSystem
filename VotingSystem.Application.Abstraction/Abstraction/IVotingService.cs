using VotingSystem.Domain;

namespace VotingSystem.Application.Abstraction
{
    public interface IVotingService
    {
        public Task<List<Voting>> GetAllVotes();
        public Task AddVote(int voterId, int candidateId);
        public Task<int> GetCandidateVotingCount(int candidateId);
    }
}
