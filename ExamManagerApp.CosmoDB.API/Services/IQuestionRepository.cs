using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public interface IQuestionRepository
    {
        Task<QuestionDocument> GetAsync(string questionId);
        Task<IEnumerable<QuestionDocument>> GetByTypeAsync(string questionType);
        Task<IEnumerable<QuestionDocument>> ListAsync();

        Task<QuestionDocument> CreateAsync(QuestionCreateDto question);
        Task<QuestionDocument> UpdateAsync(QuestionUpdateDto question, string questionType);
        Task DeleteAsync(string questionId, string group);

    }
}
