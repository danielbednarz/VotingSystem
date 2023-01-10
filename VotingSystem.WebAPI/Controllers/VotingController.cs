using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;

namespace VotingSystem.WebAPI
{
    public class VotingController : AppController
    {
        private readonly IVotingService _votingService;

        public VotingController(IVotingService votingService)
        {
            _votingService = votingService;
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
