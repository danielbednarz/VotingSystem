using VotingSystem.Domain;

namespace VotingSystem.Data.Abstraction
{
    public interface IVoterRepository : IRepository<Voter>
    {
        public Task<bool> IsVoterAlreadyExists(string name);
    }
}
