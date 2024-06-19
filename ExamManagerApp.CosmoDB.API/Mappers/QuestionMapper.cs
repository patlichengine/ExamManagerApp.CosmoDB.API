using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDocument ToQuestionDocument(this QuestionCreateDto model)
        {
            string newId = Guid.NewGuid().ToString();
            return new QuestionDocument
            {
                Id = newId,
                QuestionId = newId,
                QuestionType = model.QuestionType
            };
        }

        public static QuestionDocument ToQuestionDocument(this QuestionUpdateDto model, string questionId)
        {
            return new QuestionDocument
            {
                Id = model.Id,
                QuestionId = questionId,
                QuestionType = model.QuestionType
            };
        }
        
        private static string getQuestionType(bool yesNo, bool dropDown, bool multipleChoise)
        {
            string defaultype = "General";
            if (yesNo) { return "YesNo"; }
            else if (dropDown) { return "Drop Down"; }
            else if (multipleChoise) { return "Multiple Choise"; }
            else return defaultype;
        }
    }
}

