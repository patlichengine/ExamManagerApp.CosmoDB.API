using ExamManagerApp.CosmoDB.API.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly Container questionTypeContainer;

        public QuestionTypeRepository(string connectionString, string primaryKey, string databaseName)
        {
            //create the configuration for the cosmos database for the question containers
            var cosmosClient = new CosmosClient(connectionString, primaryKey, new CosmosClientOptions() { });

            var questionContainerName = "QuestionTypes";
            questionTypeContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        }

        public async Task<QuestionType> GetQuestionTypeByIdAsync(string questionTypeId)
        {
            var query = questionTypeContainer.GetItemLinqQueryable<QuestionType>()
                .Where(u => u.Id == questionTypeId)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<QuestionType> CreateQuestionTypeAsync(QuestionType questionType)
        {
            var response = await questionTypeContainer.CreateItemAsync(questionType);
            return response.Resource;
        }

        public async Task<QuestionType> UpdateQuestionTypeAsync(QuestionType questionType)
        {
            var response = await questionTypeContainer.ReplaceItemAsync(questionType, questionType.Id);
            return response.Resource;
        }

        public async Task DeleteQuestionTypeAsync(string questionTypeId)
        {
            await questionTypeContainer.DeleteItemAsync<QuestionType>(questionTypeId, new PartitionKey(questionTypeId));
        }
    }
}
