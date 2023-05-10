using CQRSMediatR.Features.Commands.Response;
using MediatR;

namespace CQRSMediatR.Features.Commands.Request
{
    public class DeleteBookCommandRequest :IRequest<DeleteBookCommandResponse>
    {
        public DeleteBookCommandRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}