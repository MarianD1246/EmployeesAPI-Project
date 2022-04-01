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
        private readonly IRepository<Employee> _service;
        public EmployeesController(IRepository<Employee> repository)
        {
            _service = repository;
        }

        // GET: api/Employees contains all employee searches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
        { 
            List<EmployeeDTO> employeeList = new();
            var cityQuery = HttpContext.Request.Query["city"];
            var countryQuery = HttpContext.Request.Query["country"];
            var idQuery = HttpContext.Request.Query["id"];

            if (Int32.TryParse(idQuery, out int id))
            {
                employeeList.Add(Utilities.EmployeeToDTO(await _service.GetItemByIdAsync(id)));
            }
            else if (!String.IsNullOrEmpty(cityQuery))
            {
                Predicate<Employee> predicate = e => e.City.Equals(cityQuery.ToString());
                employeeList = _service.GetItemByPredicateAsync(predicate);    
            }
            else if (!String.IsNullOrEmpty(countryQuery))
            {
                Predicate<Employee> predicate = e => e.Country.Equals(countryQuery.ToString());
                employeeList = _service.GetItemByPredicateAsync(predicate);
            }
            else return _service.GetAllItems(); 
            
            if (employeeList.Count == 0) return BadRequest();
            else return employeeList;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")] 
        //int id is provided in the search bar, and employee is coming from the postman text body
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var employeeFromDB = await _service.GetItemByIdAsync(id);
            if (employeeFromDB == null)
            {
                return NotFound();
            }

            employeeFromDB.LastName = employee.LastName;
            employeeFromDB.FirstName = employee.FirstName;
            employeeFromDB.Title = employee.Title;
            employeeFromDB.Region = employee.Region;

            try
            {
                await _service.SaveItemChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_service.ItemExists(id))
            {
                return NotFound();
            }

            return Created("Update Complete", employee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employee)
        {
            await _service.CreateItemAsync(Utilities.DTOToEmployee(employee));
            return CreatedAtAction( nameof(GetEmployee), new { id = employee.EmployeeId }, Utilities.DTOToEmployee(employee));
            //ID doens't increment in the post method
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]//Decrement the id value form our db
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = _service.GetItemByIdAsync(id);
            employee.Wait();
            if (employee.Result == null)
            {
                return NotFound();
            }

            await _service.RemoveItemAsync(employee.Result);

            return NoContent();
        }
    }
}