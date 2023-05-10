namespace CQRSMediatR.Features.Commands.Response
{
    public class UpdateBookCommandResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
    }
}
