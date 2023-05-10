using CQRSMediatR.Context;
using CQRSMediatR.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace CQRSMediatR.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoDbContext dbContext;
        protected IMongoCollection<TEntity> dbCollection;
        public ReadRepository(IMongoDbContext mongoDbContext)
        {

            dbContext = mongoDbContext;
            dbCollection = dbContext.GetCollection<TEntity>();
        }
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbCollection.AsQueryable().AnyAsync(expression);
        }

        public virtual IMongoQueryable<TEntity> GetAll()
        {
            return dbCollection.AsQueryable();
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await dbCollection.Find(collection => collection.Id == id).FirstOrDefaultAsync();
        }

        public virtual IMongoQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
        {
            return dbCollection.AsQueryable().Where(expression);
        }
    }
}
