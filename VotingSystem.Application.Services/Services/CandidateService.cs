using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            List<Candidate> candidates = await _candidateRepository.GetAllAsync();

            return candidates;
        }

        public async Task<int> AddCandidate(string name)
        {
            Candidate candidate = new()
            {
                Name = name
            };

            await _candidateRepository.AddAsync(candidate);
            if (!await _candidateRepository.SaveAsync())
            {
                throw new Exception("Error during saving the candidate");
            }

            return candidate.Id;
        }
    }
}
