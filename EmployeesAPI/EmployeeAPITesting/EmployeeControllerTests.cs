using EmployeesAPI;
using EmployeesAPI.Controllers;
using EmployeesAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPITesting
{
    public class EmployeeControllerTests
    {

        private NorthwindContext? _context;
        private EmployeeService? _service;
        private EmployeesController? _sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase(databaseName: "ExampleDb").Options;
            _context = new NorthwindContext(options);
            _service = new EmployeeService(_context); //Service needs to be a Mock
            //_sut = new EmployeesController(_context);
            foreach (Employee emp in TestEmpolyeesDataSource.EmployeesList)
            {
                _service.CreateItemAsync(emp);
            }
        }

        [Test]
        public void GivenAValidId_GetTodoItemById_ReturnsCorrectItem()
        {
            //var result = _sut.GetEmployeeById(0).Result;
            //Assert.That(result, Is.Not.Null);
            //Assert.That(result.Value, Is.TypeOf<Employee>());
            //Assert.That(result.Value.FirstName, Is.EqualTo("Bob"));
        }

    }
}
