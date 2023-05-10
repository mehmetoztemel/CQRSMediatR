using CQRSMediatR.Features.Commands.Response;
using MediatR;

namespace CQRSMediatR.Features.Commands.Request
{
    public class UpdateBookCommandRequest :IRequest<UpdateBookCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
