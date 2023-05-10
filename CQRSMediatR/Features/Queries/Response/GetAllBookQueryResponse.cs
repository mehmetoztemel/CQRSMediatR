namespace CQRSMediatR.Features.Queries.Response
{
    public class GetAllBookQueryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
    }
}
