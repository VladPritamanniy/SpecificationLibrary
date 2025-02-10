using Ardalis.Specification.Audit;

namespace TestArdalisSpecification.Core.Entities
{
    public class Office : IAuditable
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
