using MongoDB.Driver;

namespace TestMaker.Evaluation.Persistence.Context
{
    public class EvaluationDbContext
    {
        private readonly IMongoDatabase _database;

        public EvaluationDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Domain.Entities.Evaluation> Evaluations => _database.GetCollection<Domain.Entities.Evaluation>("evaluations");
    }
}
