using CFP.Api.Models.Entities;

namespace CFP.Api.Models.DTOs
{
    public class CallForPaperUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid? ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public CallForPaperStatus? CallForPaperStatus { get; set; }
    }
}
