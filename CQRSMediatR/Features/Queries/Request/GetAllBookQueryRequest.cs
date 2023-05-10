using CQRSMediatR.Features.Queries.Response;
using MediatR;

namespace CQRSMediatR.Features.Queries.Request
{
    public class GetAllBookQueryRequest :IRequest<List<GetAllBookQueryResponse>>
    {
    }
}
