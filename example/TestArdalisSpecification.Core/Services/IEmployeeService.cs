using TestArdalisSpecification.Core.Entities;

namespace TestArdalisSpecification.Core.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeListAsync();
        Task<List<Employee>> GetEmployeeByNameAsync(string firstName);
        Task CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
    }
}
