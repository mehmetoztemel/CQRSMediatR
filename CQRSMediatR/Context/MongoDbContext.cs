using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CQRSMediatR.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            _client = new MongoClient(options.Value.ConnectionString);
            _database = _client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
