using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;
using WebApplicationAPI.Services;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmpController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _employeeService.GetAllEmployeesAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee emp)
        {
            var result = await _employeeService.AddEmployeeAsync(emp);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
