using CQRSMediatR.Entities;
using CQRSMediatR.Features.Commands.Request;
using CQRSMediatR.Features.Commands.Response;
using CQRSMediatR.Repositories;
using MediatR;

namespace CQRSMediatR.Features.Handlers.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IBookWriteRepository _writeRepository;
        public CreateBookCommandHandler(IBookWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = new Book() { Name = request.Name, Author = request.Author };
            await _writeRepository.AddAsync(book);
            return new CreateBookCommandResponse()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                IsDeleted = book.IsDeleted,
            };
        }
    }
}
