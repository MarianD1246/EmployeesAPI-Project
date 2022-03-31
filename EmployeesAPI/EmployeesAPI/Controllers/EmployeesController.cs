#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI;
using EmployeesAPI.Model;
using EmployeesAPI.Services;

namespace EmployeesAPI.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employees contains all employee searches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
        {
            List<EmployeeDTO> employeeList = new();
            Employee employee = new();

            var surnameQuery = HttpContext.Request.Query["surname"];
            var firstNameQuery = HttpContext.Request.Query["firstname"];
            var cityQuery = HttpContext.Request.Query["city"];
            var jobTitleQuery = HttpContext.Request.Query["jobtitle"];
            var idQuery = HttpContext.Request.Query["id"];

            if (Int32.TryParse(idQuery, out int id))
            {
                return await GetById(id);
            }
            else if (!String.IsNullOrEmpty(surnameQuery))
            {
                employeeList = await GetByName(surnameQuery.ToString(), firstNameQuery);
            }
            else if (!String.IsNullOrEmpty(cityQuery))
            {
                var city = cityQuery.ToString();
                employeeList = (await _context.Employees.Where(e => e.City == city).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync());
            }
            else if (!String.IsNullOrEmpty(jobTitleQuery))
            {
                var jobTitle = jobTitleQuery.ToString();
                employeeList = await _context.Employees.Where(e => e.Title == jobTitle.Replace('-', ' ')).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();
            }
            else
            {
                employeeList = await _context.Employees.Select(x => Utilities.EmployeeToDTO(x)).ToListAsync();
            }

            if (employeeList.Count == 0) return NotFound();
            else return employeeList;
        }


        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetById(int id)
        {
            List<EmployeeDTO> employeeList = new();

            Employee employee = (await _context.Employees.FindAsync(id));
            if (employee != null)
            {
                employeeList.Add(Utilities.EmployeeToDTO(employee)); 
            }
            return employeeList;
        }

        public async Task<List<EmployeeDTO>> GetByName(string lastName, Microsoft.Extensions.Primitives.StringValues firstNameQuery)
        {
            List<EmployeeDTO> employeeList = new();
            if (!String.IsNullOrEmpty(firstNameQuery))
            {
                var firstName = firstNameQuery.ToString();
                employeeList = await _context.Employees.Where(e => e.LastName == lastName && e.FirstName == firstName).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();
            }
            else employeeList = await _context.Employees.Where(e => e.LastName == lastName).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();

            return employeeList;
        }
    }
}