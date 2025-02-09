using Ardalis.Specification;
using TestArdalisSpecification.Core.Entities;
using TestArdalisSpecification.Core.Services;
using TestArdalisSpecification.Core.Specifications;

namespace TestArdalisSpecification.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryBase<Employee> _employeeRepository;

        public EmployeeService(IRepositoryBase<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<List<Employee>> GetEmployeeByNameAsync(string firstName)
        {
            return await _employeeRepository.ListAsync(new EmployeeByNameSpecification(firstName));
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            var employee1 = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                JobTitle = "Software Developer",
                Department = "IT",
                OfficeId = employee.OfficeId
            };
            _employeeRepository.Add(employee);
            _employeeRepository.Add(employee1);
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            return employee;
        }
    }
}
