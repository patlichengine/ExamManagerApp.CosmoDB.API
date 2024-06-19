using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;

namespace ExamManagerApp.CosmoDB.API.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDocument ToQuestionDocument(this QuestionCreateDto model)
        {
            return new QuestionDocument
            {
                Id = Guid.NewGuid().ToString(),
                Paragraph = model.Paragraph,
                QuestionType = getQuestionType(model.YesNo, model.Dropdown, model.MultipleChoice),
                YesNo = model.YesNo,
                Dropdown = model.Dropdown,
                MultipleChoice = model.MultipleChoice,
                Date = model.Date.Date,
                Number = model.Number
            };
        }

        public static QuestionDocument ToQuestionDocument(this QuestionUpdateDto model, string questionType)
        {
            return new QuestionDocument
            {
                Id = model.Id,
                Paragraph = model.Paragraph,
                QuestionType = questionType,
                YesNo = model.YesNo,
                Dropdown = model.Dropdown,
                MultipleChoice = model.MultipleChoice,
                Date = model.Date.Date,
                Number = model.Number
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

