using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Senwell_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<EmployeeClass> employees = new List<EmployeeClass>
        {
            new EmployeeClass { EmployeeId = "123", FirstName = "John", LastName = "Doe", Department = "IT", Address = "123 Street", HireDate = "01-02-2023", Dob = "01-02-2012", JoiningDate = "20-02-2023", Salary = 123 },
            // Add more sample data here
        };

        // 1) Filter by department
        [HttpGet("filter-by-department")]
        public IActionResult GetByDepartment([FromQuery] string department)
        {
            var result = employees.Where(e => e.Department == department).ToList();
            return Ok(result);
        }

        // 2) Sort by salary
        [HttpGet("sort-by-salary")]
        public IActionResult GetSortedBySalary()
        {
            var result = employees.OrderBy(e => e.Salary).ToList();
            return Ok(result);
        }

        // 3) Search by employee_id
        [HttpGet("search-by-id")]
        public IActionResult GetById([FromQuery] string employeeId)
        {
            var result = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}