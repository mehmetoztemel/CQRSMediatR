using MongoDB.Driver;

namespace CQRSMediatR.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}
