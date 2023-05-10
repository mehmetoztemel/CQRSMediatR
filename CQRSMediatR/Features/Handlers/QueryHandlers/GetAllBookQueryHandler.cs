using CQRSMediatR.Features.Queries.Request;
using CQRSMediatR.Features.Queries.Response;
using CQRSMediatR.Repositories;
using MediatR;
using MongoDB.Driver;

namespace CQRSMediatR.Features.Handlers.QueryHandlers
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, List<GetAllBookQueryResponse>>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetAllBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        public async Task<List<GetAllBookQueryResponse>> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            var dataList = await _bookReadRepository.GetAll().ToListAsync(cancellationToken);
            List<GetAllBookQueryResponse> list = new List<GetAllBookQueryResponse>();
            foreach (var data in dataList)
            {
                var book = new GetAllBookQueryResponse
                {
                    Id = data.Id,
                    Name = data.Name,
                    Author = data.Author,
                    IsDeleted = data.IsDeleted,
                };
                list.Add(book);
            }
            return list;
        }
    }
}
