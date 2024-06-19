//using ExamManagerApp.CosmoDB.API.Services;
//using Microsoft.AspNetCore.Mvc;
//using Xunit;

//namespace ExamManagerApp.CosmoDB.API.Tests
//{
//    public class QuestionCOntrollerTest
//    {
//        private readonly Mock<IQuestionRepository> _mockService;
//        private readonly ExampleController _controller;

//        public QuestionCOntrollerTest()
//        {
//            _mockService = new Mock<IExampleService>();
//            _controller = new ExampleController(_mockService.Object);
//        }

//        [Fact]
//        public async Task Get_ReturnsOkResult()
//        {
//            _mockService.Setup(service => service.GetDataAsync()).ReturnsAsync(new List<string>());

//            var result = await _controller.Get();

//            Assert.IsType<OkObjectResult>(result);
//        }
//    }
//}
