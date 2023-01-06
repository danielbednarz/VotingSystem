namespace VotingSystem.Application.Abstraction
{
    public interface IVotingService
    {
        public Task AddVote(int voterId, int candidateId);
    }
}
