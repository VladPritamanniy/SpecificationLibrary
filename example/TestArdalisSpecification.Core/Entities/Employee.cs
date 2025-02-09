using Ardalis.Specification.Audit;

namespace TestArdalisSpecification.Core.Entities
{
    public class Employee : IAuditable
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
    }
}
