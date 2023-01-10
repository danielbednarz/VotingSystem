using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        private readonly IVotingRepository _votingRepository;

        public VoterService(IVoterRepository voterRepository, IVotingRepository votingRepository)
        {
            _voterRepository = voterRepository;
            _votingRepository = votingRepository;
        }

        public async Task<List<VoterVM>> GetAllVoters()
        {
            List<Voter> voters = await _voterRepository.GetAllAsync();
            List<VoterVM> voterVMs = new();

            foreach (Voter voter in voters)
            {
                voterVMs.Add(new VoterVM
                {
                    Id = voter.Id,
                    Name = voter.Name,
                    HasVoted = await _votingRepository.IsVoterAlreadyVoted(voter.Id)
                });
            }

            return voterVMs;
        }

        public async Task<int> AddVoter(string name)
        {
            if (await _voterRepository.IsVoterAlreadyExists(name))
            {
                throw new Exception("Voter with given name already exists");
            }

            Voter voter = new()
            {
                Name = name
            };

            await _voterRepository.AddAsync(voter);
            if (!await _voterRepository.SaveAsync())
            {
                throw new Exception("Error during saving the voter");
            }

            return voter.Id;
        }
    }
}
