using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.WebAPI
{
    public class VotingController : AppController
    {
        private readonly IVotingService _votingService;

        public VotingController(IVotingService votingService)
        {
            _votingService = votingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVotes()
        {
            List<Voting> votes = await _votingService.GetAllVotes();

            return Ok(votes);
        }

        [HttpGet("candidateVotingCount/{id}")]
        public async Task<IActionResult> GetCandidateVotingCount(int id)
        {
            int votingCount = await _votingService.GetCandidateVotingCount(id);

            return Ok(votingCount);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(AddVoteDTO voteDTO)
        {
            if (voteDTO != null)
            {
                await _votingService.AddVote(voteDTO.VoterId, voteDTO.CandidateId);

                return Ok();
            }

            return NotFound("Invalid data");
        }

        

    }
}
