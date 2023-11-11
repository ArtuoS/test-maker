using MongoDB.Driver;
using TestMaker.Authentication.Domain.Entities;

namespace TestMaker.Authentication.Persistence.Context
{
    public class AuthenticationDbContext
    {
        private readonly IMongoDatabase _database;

        public AuthenticationDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("accounts");
    }
}
