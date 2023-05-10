using CQRSMediatR.Context;
using CQRSMediatR.Entities;
using MongoDB.Driver;

namespace CQRSMediatR.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoDbContext dbContext;
        protected IMongoCollection<TEntity> dbCollection;
        public WriteRepository(IMongoDbContext mongoDbContext)
        {
            dbContext = mongoDbContext;
            dbCollection = dbContext.GetCollection<TEntity>();
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.IsDeleted = false;
            await dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            //var filter = Builders<TEntity>.Filter.Eq(m=> m.Id, id);
            //await dbCollection.DeleteOneAsync(filter);
            //DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            //return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

            var entity = await dbCollection.Find(collection => collection.Id == id).FirstOrDefaultAsync();
            entity.IsDeleted = true;
            //await dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq(m => m.Id, entity.Id), entity);

            var updateResult = await dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq(m => m.Id, entity.Id), entity);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.IsDeleted = false;
            await dbCollection.ReplaceOneAsync(c => c.Id == entity.Id, entity);
            return entity;
        }
    }
}
