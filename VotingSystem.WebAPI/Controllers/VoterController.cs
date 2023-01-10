using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;

namespace VotingSystem.WebAPI
{
    public class VoterController : AppController
    {
        private readonly IVoterService _voterService;

        public VoterController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VoterVM>>> GetAllVoters()
        {
            List<VoterVM> voters = await _voterService.GetAllVoters();

            return Ok(voters);
        }

        [HttpPost]
        public async Task<IActionResult> AddVoter(string name)
        {
            int voterId = await _voterService.AddVoter(name);

            return Ok(voterId);
        }

    }
}
