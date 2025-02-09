namespace TestArdalisSpecification.Core.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
