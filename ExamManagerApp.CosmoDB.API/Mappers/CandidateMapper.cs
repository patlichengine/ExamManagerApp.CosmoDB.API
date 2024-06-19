using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Mappers
{
    public static class CandidateMapper
    {
        public static CandidateDocument ToCandidateDocument(this CandidateCreateDto model)
        {
            return new CandidateDocument
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Nationality = model.Nationality,
                CurrentResidence = model.CurrentResidence,
                IDNumber = model.IDNumber,
                DateOfBirth = model.DateOfBirth,
                Category = "Basic"
            };
        }

    }
}

