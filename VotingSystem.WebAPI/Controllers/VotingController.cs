using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.WebAPI
{
    public class VotingController : AppController
    {
        private readonly IVoterRepository _voterRepository;
        private readonly IVotingRepository _votingRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVotingService _votingService;

        public VotingController(IVotingRepository votingRepository, ICandidateRepository candidateRepository, IVoterRepository voterRepository, IVotingService votingService)
        {
            _votingRepository = votingRepository;
            _candidateRepository = candidateRepository;
            _voterRepository = voterRepository;
            _votingService = votingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVotes()
        {
            List<Voting> votes = await _votingRepository.GetAllAsync();

            return Ok(votes);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int voterId, int candidateId)
        {
            Voter voter = await _voterRepository.FirstOrDefaultAsync(x => x.Id == voterId);
            Candidate candidate = await _candidateRepository.FirstOrDefaultAsync(x => x.Id == candidateId);

            if (voter != null && candidate != null)
            {
                await _votingService.AddVote(voter.Id, candidate.Id);

                return Ok();
            }

            return NotFound("Cannot add vote");
        }
      
    }
}
