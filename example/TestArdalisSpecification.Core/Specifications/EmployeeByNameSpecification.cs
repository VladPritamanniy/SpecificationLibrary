using Ardalis.Specification;
using TestArdalisSpecification.Core.Entities;

namespace TestArdalisSpecification.Core.Specifications
{
    public class EmployeeByNameSpecification : Specification<Employee>
    {
        public EmployeeByNameSpecification(string firstName)
        {
            Query.Where(p => p.FirstName == firstName);
        }
    }
}
