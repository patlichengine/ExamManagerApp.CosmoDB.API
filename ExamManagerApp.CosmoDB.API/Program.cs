using ExamManagerApp.CosmoDB.API.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("cosmosDBConn");
var primaryKey = configuration["CosmosConfig:primaryKey"];
var databaseName = configuration["CosmosConfig:databaseName"];

// Add services to the container.
//create the connection to the cosmo db database here using the CosmosClient
builder.Services.AddSingleton((provider) =>
{
    /* use the confirgation in the appsettings.json for the key CosmosDBSettings to 
     * configure the enpointUrl, primary key and the database name
     */
    //instantiate the client option for the Cosmo DB
    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = databaseName
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    var cosmosClient = new CosmosClient(connectionString, primaryKey, cosmosClientOptions);

    //connect to the local database otherwise change the connection mode to Gateway
    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;

    return cosmosClient;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add the services using dependency injection
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>(provider =>
    new QuestionRepository(connectionString, primaryKey, databaseName));
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>(provider =>
    new CandidateRepository(connectionString, primaryKey, databaseName));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
