using EmployeeApi.Core.Data;
using EmployeeApi.Core.DTOs;
using EmployeeApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeApi.DAL;

namespace EmployeeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(AppDbContext context)
        {
            _employeeService = EmployeeService.GetInstance(context); // Singleton pattern
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeCreateDTO dto)
        {
            var emp = await _employeeService.CreateAsync(dto);
            return Ok(emp);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EmployeeUpdateDTO dto)
        {
            try
            {
                var emp = await _employeeService.UpdateAsync(dto);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _employeeService.DeactivateAsync(id);
            return result ? Ok("Employee deactivated") : NotFound("Employee not found");
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id.HasValue)
            {
                var emp = await _employeeService.GetByIdAsync(id.Value);
                return emp != null ? Ok(emp) : NotFound("Employee not found");
            }

            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }
    }
}
