namespace Ardalis.Specification.EntityFrameworkCore.Audit
{
    public class Audits
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Sql { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
