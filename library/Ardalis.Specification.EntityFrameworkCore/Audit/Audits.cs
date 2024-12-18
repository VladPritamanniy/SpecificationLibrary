namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class Audits
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? EntityName { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
