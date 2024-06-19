using ExamManagerApp.CosmoDB.API.DTOs;
using ExamManagerApp.CosmoDB.API.Mappers;
using ExamManagerApp.CosmoDB.API.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace ExamManagerApp.CosmoDB.API.Services
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly Container _candidateContainer;

        public CandidateRepository(string connectionString, string primaryKey, string databaseName)
        {
            //create the configuration for the cosmos database for the candidate containers
            var cosmosClient = new CosmosClient(connectionString, primaryKey, new CosmosClientOptions() { });

            var containerName = "Candidates";
            _candidateContainer = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<CandidateDocument> CreateAsync(CandidateCreateDto candidate)
        {
            //create the candidate document using the mapper
            var payload = candidate.ToCandidateDocument();

            var response = await _candidateContainer.CreateItemAsync(payload);
            return response.Resource;
        }

        public async Task<CandidateDocument> GetAsync(string candidateId)
        {
            //Get the candidate id
            var query = _candidateContainer.GetItemLinqQueryable<CandidateDocument>()
                .Where(t => t.Id == candidateId)
                .Take(1)    //likey that there can be more candidate ids
                .ToFeedIterator();

            var response = await query.ReadNextAsync();
            //return the result of the query
            return response.FirstOrDefault();
        }
    }
}
