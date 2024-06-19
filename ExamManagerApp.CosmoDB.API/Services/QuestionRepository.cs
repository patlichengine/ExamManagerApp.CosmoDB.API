using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Mappers;
using ExamManagerApp.CosmoDB.API.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Container _questionContainer;

        public QuestionRepository(string connectionString, string primaryKey, string databaseName)
        {
            //create the configuration for the cosmos database for the question containers
            var cosmosClient = new CosmosClient(connectionString, primaryKey, new CosmosClientOptions() { });

            var questionContainerName = "Questions";
            _questionContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        }

        public async Task<QuestionDocument> CreateAsync(QuestionCreateDto question)
        {
            //create the question document using the mapper
            var questionPayload = question.ToQuestionDocument();

            var response = await _questionContainer.CreateItemAsync(questionPayload);
            return response.Resource;
        }

        public async Task DeleteAsync(string questionId, string questionType)
        {
            await _questionContainer.DeleteItemAsync<QuestionDocument>(questionId, new PartitionKey(questionType));
            
        }

        /// <summary>
        /// This method gets only a single question document
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<QuestionDocument> GetAsync(string questionId)
        {
            //Get the question id
            var query = _questionContainer.GetItemLinqQueryable<QuestionDocument>()
                .Where(t => t.Id == questionId)
                .Take(1)    //likey that there can be more question ids
                .ToFeedIterator();  // .ToQueryDefinition();

            //return a query and map it with the model class
            //var response = await _questionContainer.GetItemQueryIterator<QuestionDocument>(query).ReadNextAsync();

            var response = await query.ReadNextAsync();
            //return the result of the query
            return response.FirstOrDefault();
        }

        /// <summary>
        /// This method get all the record in the database for each page and page size
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QuestionDocument>> ListAsync()
        {
            var query = _questionContainer.GetItemLinqQueryable<QuestionDocument>()
                .ToFeedIterator();

            var questions = new List<QuestionDocument>();

            while(query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<IEnumerable<QuestionDocument>> GetByTypeAsync(string questionType)
        {
            var query = _questionContainer.GetItemLinqQueryable<QuestionDocument>()
                .Where(s => s.QuestionType == questionType)
                .ToFeedIterator();

            var questions = new List<QuestionDocument>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<QuestionDocument> UpdateAsync(QuestionUpdateDto question, string questionType)
        {
            // create an object of the question document using the update dto
            var updatePayload = question.ToQuestionDocument(questionType);
            var response = await _questionContainer.ReplaceItemAsync(updatePayload, updatePayload.Id);
            return response.Resource;
        }
    }
}
