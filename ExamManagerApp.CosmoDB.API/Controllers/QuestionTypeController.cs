using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagerApp.CosmoDB.API.Controllers
{
    [Route("api/question-types")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeRepository _questionTypeService;

        public QuestionTypeController(IQuestionTypeRepository questionTypeService)
        {
            _questionTypeService = questionTypeService ?? throw new ArgumentNullException(nameof(questionTypeService));
        }

        [HttpGet("{questiontypeId}")]
        public async Task<ActionResult<QuestionType>> GetQuestionType(string questiontypeId)
        {
            var questiontype = await _questionTypeService.GetQuestionTypeByIdAsync(questiontypeId);
            if (questiontype == null)
            {
                return NotFound();
            }

            return questiontype;
        }

        [HttpPost]
        public async Task<ActionResult<QuestionType>> CreateQuestionType(QuestionType questiontype)
        {
            // Set any additional properties if required

            var created = await _questionTypeService.CreateQuestionTypeAsync(questiontype);
            return CreatedAtAction(nameof(GetQuestionType), new { questiontypeId = created.Id }, created);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<QuestionType>> UpdateQuestionType(string questiontypeId, QuestionType questiontype)
        {
            var existing = await _questionTypeService.GetQuestionTypeByIdAsync(questiontypeId);
            if (existing == null)
            {
                return NotFound();
            }

            var updated = await _questionTypeService.UpdateQuestionTypeAsync(questiontype);
            return Ok(updated);
        }
        [HttpDelete("{questiontypeId}")]
        public async Task<IActionResult> DeleteQuestionType(string questiontypeId)
        {
            var existing = await _questionTypeService.GetQuestionTypeByIdAsync(questiontypeId);
            if (existing == null)
            {
                return NotFound();
            }

            await _questionTypeService.DeleteQuestionTypeAsync(questiontypeId);
            return NoContent();
        }

    }
}
