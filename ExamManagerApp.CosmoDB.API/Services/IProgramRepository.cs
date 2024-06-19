using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public interface IProgramRepository
    {
        Task<ProgramDocument> CreateProgramAsync(ProgramDocument program);
        Task DeleteProgramAsync(string programId);
        Task<ProgramDocument> GetProgramByIdAsync(string programId);
        Task<ProgramDocument> UpdateProgramAsync(ProgramDocument program);

    }
}
