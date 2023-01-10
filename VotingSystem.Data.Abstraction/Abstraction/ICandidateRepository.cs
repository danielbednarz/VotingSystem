using VotingSystem.Domain;

namespace VotingSystem.Data.Abstraction
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        public Task<bool> IsCandidateAlreadyExists(string name);
    }
}
