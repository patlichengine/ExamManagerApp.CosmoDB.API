using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public interface IQuestionTypeRepository
    {
        Task<QuestionType> CreateQuestionTypeAsync(QuestionType qtype);
        Task DeleteQuestionTypeAsync(string qtypeId);
        Task<QuestionType> GetQuestionTypeByIdAsync(string qtypeId);
        Task<QuestionType> UpdateQuestionTypeAsync(QuestionType qtype);

    }
}
