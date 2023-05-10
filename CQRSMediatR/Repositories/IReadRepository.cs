using CQRSMediatR.Entities;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace CQRSMediatR.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        IMongoQueryable<TEntity> GetAll();
        IMongoQueryable<TEntity> GetWhere(Expression<Func<TEntity,bool>> expression);
        Task<TEntity> GetByIdAsync(string id);
        Task<bool> AnyAsync(Expression<Func<TEntity,bool>> expression);
    }
}
