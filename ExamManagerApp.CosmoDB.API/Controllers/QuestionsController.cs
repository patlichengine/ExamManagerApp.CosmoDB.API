using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagerApp.CosmoDB.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository questionService;
        //private readonly ILogger<QuestionsController> logger;

        public QuestionsController(IQuestionRepository questionService)
        {
            this.questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
            //this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Create a question using the required parameters
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<QuestionDocument>> Create(QuestionCreateDto question)
        {
            var created = await questionService.CreateAsync(question);
            return CreatedAtAction(nameof(Get), new { questionId = created.Id }, created);
        }

        /// <summary>
        /// Get a question based on the question id
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [HttpGet("{questionId}")]
        public async Task<ActionResult<QuestionDocument>> Get(string questionId)
        {
            // get all the questions in the database
            var question = await questionService.GetAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        /// <summary>
        /// List all the items in the questiion collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDocument>>> GetQuestions()
        {
            // get all the questions in the database
            var questions = await questionService.ListAsync();
            if (questions == null)
            {
                return NotFound();
            }
            return Ok(questions);
        }

        [HttpGet("search/{questionType}")]
        public async Task<ActionResult<IEnumerable<QuestionDocument>>> GetQuestionsByType(string questionType)
        {
            // get all the questions in the database
            var questions = await questionService.GetByTypeAsync(questionType);
            if (questions == null)
            {
                return NotFound();
            }
            return Ok(questions);
        }


        /// <summary>
        /// Update the question item
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut("{questionId}")]
        public async Task<ActionResult<QuestionDocument>> Update(string questionId, QuestionUpdateDto question)
        {
            // check if the question exists
            var existingQuestion = await questionService.GetAsync(questionId);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            // update the current question
            var updated = await questionService.UpdateAsync(question, existingQuestion.QuestionType);
            return Ok(updated);
        }

        /// <summary>
        /// Delete the currently selected question with the id
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [HttpDelete("{questionId}")]
        public async Task<ActionResult> Delete(string questionId)
        {
            // check if the question exists
            var existingQuestion = await questionService.GetAsync(questionId);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            // delete the current question
            await questionService.DeleteAsync(questionId, existingQuestion.QuestionType);
            return NoContent();
        }
    }

}
