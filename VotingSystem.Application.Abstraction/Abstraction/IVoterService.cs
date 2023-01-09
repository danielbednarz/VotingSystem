using VotingSystem.Domain;

namespace VotingSystem.Application.Abstraction
{
    public interface IVoterService
    {
        public Task<List<VoterVM>> GetAllVoters();
        public Task<int> AddVoter(string name);
    }
}
