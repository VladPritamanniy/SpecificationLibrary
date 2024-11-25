using Microsoft.AspNetCore.Mvc;
using TestArdalisSpecification.Core.Entities;
using TestArdalisSpecification.Core.Services;

namespace TestArdalisSpecification.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeListAsync()
        {
            return Ok(await _employeeService.GetEmployeeListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeByNameAsync(string firstName)
        {
            return Ok(await _employeeService.GetEmployeeByNameAsync(firstName));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] Employee employee)
        {

            return Ok(await _employeeService.CreateEmployeeAsync(employee));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] Employee employee)
        {
            return Ok(await _employeeService.UpdateEmployeeAsync(employee));
        }
    }
}
