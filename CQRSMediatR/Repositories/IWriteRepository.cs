using CQRSMediatR.Entities;

namespace CQRSMediatR.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(string id);
    }
}
