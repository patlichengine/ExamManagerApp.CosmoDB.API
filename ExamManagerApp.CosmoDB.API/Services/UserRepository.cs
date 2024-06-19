using ExamManagerApp.CosmoDB.API.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly Container _userContainer;

        public UserRepository(string connectionString, string primaryKey, string databaseName)
        {
            //create the configuration for the cosmos database for the question containers
            var cosmosClient = new CosmosClient(connectionString, primaryKey, new CosmosClientOptions() { });

            var questionContainerName = "Users";
            _userContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        }

        public async Task<UserDocument> GetUserByIdAsync(string userId)
        {
            var query = _userContainer.GetItemLinqQueryable<UserDocument>()
                .Where(u => u.Id == userId)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<UserDocument> CreateUserAsync(UserDocument user)
        {
            var response = await _userContainer.CreateItemAsync(user);
            return response.Resource;
        }

        public async Task<UserDocument> UpdateUserAsync(UserDocument user)
        {
            var response = await _userContainer.ReplaceItemAsync(user, user.Id);
            return response.Resource;
        }

        public async Task DeleteUserAsync(string userId)
        {
            await _userContainer.DeleteItemAsync<UserDocument>(userId, new PartitionKey(userId));
        }
    }
}
