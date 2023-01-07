using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.WebAPI
{
    public class CandidateController : AppController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            List<Candidate> candidates = await _candidateService.GetAllCandidates();

            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] string name)
        {
            int candidateId = await _candidateService.AddCandidate(name);

            return Ok(candidateId);
        }

    }
}
