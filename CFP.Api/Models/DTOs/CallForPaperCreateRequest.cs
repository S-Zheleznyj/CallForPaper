namespace CFP.Api.Models.DTOs
{
    public class CallForPaperCreateRequest
    {
        public Guid UserId { get; set; }
        public Guid ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
    }
}
