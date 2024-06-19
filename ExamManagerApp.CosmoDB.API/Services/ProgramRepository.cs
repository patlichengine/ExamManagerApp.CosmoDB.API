using ExamManagerApp.CosmoDB.API.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly Container _programContainer;

        public ProgramRepository(string connectionString, string primaryKey, string databaseName)
        {
            //create the configuration for the cosmos database for the question containers
            var cosmosClient = new CosmosClient(connectionString, primaryKey, new CosmosClientOptions() { });

            var questionContainerName = "Programs";
            _programContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        }

        public async Task<ProgramDocument> GetProgramByIdAsync(string programId)
        {
            var query = _programContainer.GetItemLinqQueryable<ProgramDocument>()
                .Where(u => u.Id == programId)
                .Take(1)
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<ProgramDocument> CreateProgramAsync(ProgramDocument program)
        {
            var response = await _programContainer.CreateItemAsync(program);
            return response.Resource;
        }

        public async Task<ProgramDocument> UpdateProgramAsync(ProgramDocument program)
        {
            var response = await _programContainer.ReplaceItemAsync(program, program.Id);
            return response.Resource;
        }

        public async Task DeleteProgramAsync(string programId)
        {
            await _programContainer.DeleteItemAsync<ProgramDocument>(programId, new PartitionKey(programId));
        }
    }
}
