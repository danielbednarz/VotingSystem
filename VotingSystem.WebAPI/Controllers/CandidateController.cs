using Microsoft.AspNetCore.Mvc;
using VotingSystem.Data.Abstraction;
using VotingSystem.Domain;

namespace VotingSystem.WebAPI
{
    public class CandidateController : AppController
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            List<Candidate> candidates = await _candidateRepository.GetAllAsync();

            return Ok(candidates);
        }


    }
}
