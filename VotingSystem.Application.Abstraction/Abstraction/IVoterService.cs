using VotingSystem.Domain;

namespace VotingSystem.Application.Abstraction
{
    public interface IVoterService
    {
        public Task<List<Voter>> GetAllVoters();
        public Task<int> AddVoter(string name);
    }
}
