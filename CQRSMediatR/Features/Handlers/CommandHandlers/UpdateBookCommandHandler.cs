using CQRSMediatR.Entities;
using CQRSMediatR.Features.Commands.Request;
using CQRSMediatR.Features.Commands.Response;
using CQRSMediatR.Repositories;
using MediatR;

namespace CQRSMediatR.Features.Handlers.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }
        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = new Book() {Id = request.Id,Name = request.Name,Author = request.Author };
            await _bookWriteRepository.UpdateAsync(book);
            return new UpdateBookCommandResponse() { Id = book.Id , Name = book.Name , Author = book.Author, IsDeleted = book.IsDeleted};
        }
    }
}
