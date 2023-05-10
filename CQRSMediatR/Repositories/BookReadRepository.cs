using CQRSMediatR.Context;
using CQRSMediatR.Entities;

namespace CQRSMediatR.Repositories
{
    public class BookReadRepository : ReadRepository<Book>,IBookReadRepository
    {
        public BookReadRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {
        }
    }
}
