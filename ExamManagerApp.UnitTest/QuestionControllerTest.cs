using ExamManagerApp.CosmoDB.API.Controllers;
using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Models;
using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Moq;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Metadata;

namespace ExamManagerApp.UnitTest
{
    public class QuestionControllerTest
    {
        private Mock<IQuestionRepository> questionServiceMock;
        
        public QuestionControllerTest()
        {
            questionServiceMock = new Mock<IQuestionRepository>();


        }
        private List<QuestionDocument> GetTestQuestions()
        {
            List<QuestionDocument> listOfUsers = new List<QuestionDocument> {
                new QuestionDocument
                {
                    Id = Guid.NewGuid().ToString(),
                    Paragraph = "Which of the statements is true",
                    QuestionType = "Professionals",
                    YesNo = true,
                    Dropdown = false,
                    MultipleChoice = false,
                    Date = DateTime.Now,
                    Number = 2
                },
                new QuestionDocument
                {
                    Id = Guid.NewGuid().ToString(),
                    Paragraph = "The best development IDE is ______",
                    QuestionType = "Professionals",
                    YesNo = false,
                    Dropdown = false,
                    MultipleChoice = true,
                    Date = DateTime.Now,
                    Number = 4
                }
            };

            return listOfUsers;
        }

        [Fact]
        public async Task Create_ReturnsAQuestionDocument()
        {
            // Arrange
            questionServiceMock = new Mock<IQuestionRepository>();
            var controller = new QuestionsController(questionServiceMock.Object);

            //create a new question document
            var newQuestion = new QuestionCreateDto()
            {
                Paragraph = "Which of the statements is true",
                YesNo = true,
                Dropdown = false,
                MultipleChoice = false,
                Date = DateTime.Now,
                Number = 3
            };

            // Act
            var actionResult = await controller.Create(newQuestion);

            var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            Assert.IsAssignableFrom<QuestionDocument>(createdResult.Value);
        }

        [Fact]
        public async Task GetQuestions_ReturnsAActionResult_WithAListOfQuestionDocuments()
        {
            // Arrange
            //questionServiceMock = new Mock<IQuestionRepository>();
            questionServiceMock.Setup(repo => repo.ListAsync())
                .ReturnsAsync(new List<QuestionDocument>());
            var controller = new QuestionsController(questionServiceMock.Object);

            // Act
            var result = await controller.GetQuestions();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<QuestionDocument>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetQuestions_GetAction_MustReturnOkObjectResult()
        {
            // Arrange
            //questionServiceMock = new Mock<IQuestionRepository>();
            questionServiceMock.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestQuestions());

            var controller = new QuestionsController(questionServiceMock.Object);

            // Act
            var result = await controller.GetQuestions();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<QuestionDocument>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var dtos = Assert.IsAssignableFrom<IEnumerable<QuestionDocument>>(okObjectResult);
            Assert.Equal(2, dtos.Count());
        }

      
    }
}