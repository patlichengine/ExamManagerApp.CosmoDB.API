using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public interface ICandidateRepository
    {
        Task<CandidateDocument> CreateAsync(CandidateCreateDto candidate);
        Task<CandidateDocument> GetAsync(string studentId);

    }
}
