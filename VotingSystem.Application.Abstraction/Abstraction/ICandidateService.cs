using VotingSystem.Domain;

namespace VotingSystem.Application.Abstraction
{
    public interface ICandidateService
    {
        public Task<List<CandidateVM>> GetAllCandidates();
        public Task<int> AddCandidate(string name);
    }
}
