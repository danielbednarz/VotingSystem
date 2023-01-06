using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;

        public VotingService(IVotingRepository votingRepository)
        {
            _votingRepository = votingRepository;
        }

        public async Task AddVote(int voterId, int candidateId)
        {
            if (await _votingRepository.IsVoterAlreadyVoted(voterId))
            {
                throw new Exception("User has already voted!");
            }

            Voting voting = new()
            {
                VoterId = voterId,
                CandidateId = candidateId,
            };

            _votingRepository.Add(voting);
            if (!await _votingRepository.SaveAsync())
            {
                throw new Exception("Error while trying to save vote");
            }

        }
    }
}
