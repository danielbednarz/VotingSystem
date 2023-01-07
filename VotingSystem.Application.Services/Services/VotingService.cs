using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoterRepository _voterRepository;

        public VotingService(IVotingRepository votingRepository, ICandidateRepository candidateRepository, IVoterRepository voterRepository)
        {
            _votingRepository = votingRepository;
            _candidateRepository = candidateRepository;
            _voterRepository = voterRepository;
        }

        public async Task<List<Voting>> GetAllVotes()
        {
            List<Voting> votes = await _votingRepository.GetAllAsync();

            return votes;
        }

        public async Task AddVote(int voterId, int candidateId)
        {
            Voter voter = await _voterRepository.FirstOrDefaultAsync(x => x.Id == voterId);
            Candidate candidate = await _candidateRepository.FirstOrDefaultAsync(x => x.Id == candidateId);

            if (voter == null && candidate == null)
            {
                throw new Exception("Cannot find voter or candidate");
            }

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

        public async Task<int> GetCandidateVotingCount(int candidateId)
        {
            Candidate candidate = await _candidateRepository.FirstOrDefaultAsync(x => x.Id == candidateId);

            if (candidate == null)
            {
                throw new Exception("Cannot find candidate");
            }

            int votingCount = await _votingRepository.GetCandidateVotingCount(candidateId);

            return votingCount;
        }
    }
}
