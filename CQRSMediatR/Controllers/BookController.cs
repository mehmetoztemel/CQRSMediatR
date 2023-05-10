using CQRSMediatR.Features.Commands.Request;
using CQRSMediatR.Features.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _mediator.Send(new GetAllBookQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemovoBook(string id)
        {
            var response = await _mediator.Send(new DeleteBookCommandRequest(id));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpadteBook(UpdateBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
