using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagerApp.CosmoDB.API.Controllers
{
    [Route("api/programs")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramRepository _programService;

        public ProgramsController(IProgramRepository programService)
        {
            _programService = programService ?? throw new ArgumentNullException(nameof(programService));
        }

        [HttpGet("{programId}")]
        public async Task<ActionResult<ProgramDocument>> GetProgram(string programId)
        {
            var Program = await _programService.GetProgramByIdAsync(programId);
            if (Program == null)
            {
                return NotFound();
            }

            return Program;
        }

        [HttpPost]
        public async Task<ActionResult<ProgramDocument>> CreateProgram(ProgramDocument program)
        {
            // Set any additional properties if required

            var createdProgram = await _programService.CreateProgramAsync(program);
            return CreatedAtAction(nameof(GetProgram), new { programId = createdProgram.Id }, createdProgram);
        }

        [HttpPut("{programId}")]
        public async Task<ActionResult<ProgramDocument>> UpdateProgram(string programId, ProgramDocument program)
        {
            var existingProgram = await _programService.GetProgramByIdAsync(programId);
            if (existingProgram == null)
            {
                return NotFound();
            }


            var updatedProgram = await _programService.UpdateProgramAsync(program);
            return Ok(updatedProgram);
        }
        [HttpDelete("{programId}")]
        public async Task<IActionResult> DeleteProgram(string programId)
        {
            var existingProgram = await _programService.GetProgramByIdAsync(programId);
            if (existingProgram == null)
            {
                return NotFound();
            }

            await _programService.DeleteProgramAsync(programId);
            return NoContent();
        }

    }
}
