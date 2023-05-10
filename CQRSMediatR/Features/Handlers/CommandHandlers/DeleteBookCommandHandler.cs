using CQRSMediatR.Features.Commands.Request;
using CQRSMediatR.Features.Commands.Response;
using CQRSMediatR.Repositories;
using MediatR;
using MongoDB.Driver;

namespace CQRSMediatR.Features.Handlers.CommandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        public DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteResult = await _bookWriteRepository.DeleteAsync(request.Id);
            return new DeleteBookCommandResponse() { IsSuccess = deleteResult };
        }
    }
}
