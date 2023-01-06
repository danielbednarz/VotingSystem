using Microsoft.AspNetCore.Mvc;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.WebAPI
{
    public class VoterController : AppController
    {
        private readonly IVoterRepository _voterRepository;

        public VoterController(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVoters()
        {
            List<Voter> voters = await _voterRepository.GetAllAsync();

            return Ok(voters);
        }

      
    }
}
