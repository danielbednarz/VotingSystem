using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.Application.Services
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;

        public VoterService(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public async Task<List<Voter>> GetAllVoters()
        {
            List<Voter> votes = await _voterRepository.GetAllAsync();

            return votes;
        }

        public async Task<int> AddVoter(string name)
        {
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
