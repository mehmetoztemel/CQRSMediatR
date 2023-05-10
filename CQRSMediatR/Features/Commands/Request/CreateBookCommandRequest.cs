using CQRSMediatR.Features.Commands.Response;
using MediatR;

namespace CQRSMediatR.Features.Commands.Request
{
    public class CreateBookCommandRequest :IRequest<CreateBookCommandResponse>
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
