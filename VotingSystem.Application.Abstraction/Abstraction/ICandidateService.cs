using VotingSystem.Domain;

namespace VotingSystem.Application.Abstraction
{
    public interface ICandidateService
    {
        public Task<List<Candidate>> GetAllCandidates();
        public Task<int> AddCandidate(string name);
    }
}
