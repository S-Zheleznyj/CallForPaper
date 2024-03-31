namespace CFP.Api.Models.Entities
{
    public class CallForPaper : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public CallForPaperStatus CallForPaperStatus { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Activity Activity { get; set; }
        public Guid ActivityId { get; set; }
    }
}
