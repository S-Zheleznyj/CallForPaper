namespace CFP.Api.Models.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
