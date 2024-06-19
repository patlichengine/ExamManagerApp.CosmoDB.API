using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagerApp.CosmoDB.API.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository candidateService;
        //private readonly ILogger<QuestionsController> logger;

        public CandidatesController(ICandidateRepository candidateService)
        {
            this.candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
        }

        /// <summary>
        /// Create a candidate using the required parameters
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CandidateDocument>> Apply(CandidateCreateDto payload)
        {
            var created = await candidateService.CreateAsync(payload);
            return CreatedAtAction(nameof(Get), new { candidateId = created.Id }, created);
        }

        [HttpGet("{candidateId}")]
        public async Task<ActionResult<QuestionDocument>> Get(string candidateId)
        {
            // get all the questions in the database
            var question = await candidateService.GetAsync(candidateId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

    }
}
