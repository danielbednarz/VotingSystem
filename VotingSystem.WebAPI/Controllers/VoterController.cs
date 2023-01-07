using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

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
        public async Task<IActionResult> GetAllVoters()
        {
            List<Voter> voters = await _voterService.GetAllVoters();

            return Ok(voters);
        }

        [HttpPost]
        public async Task<IActionResult> AddVoter([FromBody] string name)
        {
            int voterId = await _voterService.AddVoter(name);

            return Ok(voterId);
        }

    }
}
