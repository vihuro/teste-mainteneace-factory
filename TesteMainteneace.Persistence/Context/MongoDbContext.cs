using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Persistence.Utils;

namespace TesteMainteneace.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;

        public MongoDbContext(IOptions<ConnectionMongo> connectionMongo)
        {

            var mongoClient = new MongoClient(
                connectionString: connectionMongo.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                connectionMongo.Value.Database);

            _database = mongoDatabase;
            _client = mongoClient;

        }
        public IMongoCollection<LogsEntity> Logs
        {
            get
            {
                return _database.GetCollection<LogsEntity>("logs");
            }
            private set { }
        }
    }
}
