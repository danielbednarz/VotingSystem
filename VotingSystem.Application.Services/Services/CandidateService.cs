using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVotingRepository _votingRepository;

        public CandidateService(ICandidateRepository candidateRepository, IVotingRepository votingRepository)
        {
            _candidateRepository = candidateRepository;
            _votingRepository = votingRepository;
        }

        public async Task<List<CandidateVM>> GetAllCandidates()
        {
            List<Candidate> candidates = await _candidateRepository.GetAllAsync();
            List<CandidateVM> candidateVMs = new();

            foreach (Candidate candidate in candidates)
            {
                candidateVMs.Add(new CandidateVM
                {
                    Id = candidate.Id,
                    Name = candidate.Name,
                    VotingCount = await _votingRepository.GetCandidateVotingCount(candidate.Id)
                });
            }

            return candidateVMs;
        }

        public async Task<int> AddCandidate(string name)
        {
            if (await _candidateRepository.IsCandidateAlreadyExists(name))
            {
                throw new Exception("Candidate with given name already exists");
            }

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
