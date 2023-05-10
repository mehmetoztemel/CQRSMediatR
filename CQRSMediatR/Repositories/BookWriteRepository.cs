using CQRSMediatR.Context;
using CQRSMediatR.Entities;

namespace CQRSMediatR.Repositories
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {
        }
    }
}
