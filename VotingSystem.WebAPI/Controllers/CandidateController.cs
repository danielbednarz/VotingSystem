using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Abstraction;

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
        public async Task<ActionResult<List<CandidateVM>>> GetAllCandidates()
        {
            List<CandidateVM> candidates = await _candidateService.GetAllCandidates();

            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate(string name)
        {
            int candidateId = await _candidateService.AddCandidate(name);

            return Ok(candidateId);
        }

    }
}
