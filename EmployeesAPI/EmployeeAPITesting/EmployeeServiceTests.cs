using EmployeesAPI;
using EmployeesAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using EmployeesAPI.Model;
using EmployeesAPI.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeAPITesting
{
    public class EmployeeServiceTests
    {
        private NorthwindContext? _context;
        private EmployeeService _sut;

        [OneTimeSetUp]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "MemoryDB").Options;
            _context = new NorthwindContext(options);
            _sut = new EmployeeService(_context);

        }

        // search correct naming conventions
        [SetUp]
        public void SetUp()
        {
            TestEmpolyeesDataSource employeesCollection = new();
            foreach (var employee in employeesCollection.employeesList)
            {
                _sut.CreateItemAsync(employee);
            }
        }

        [Test]
        public void CorrectConstruction()
        {
            Assert.That(_sut, Is.InstanceOf<EmployeeService>());
        }

        [Test]
        public void GetEmpoyeeById_ProvidingAValidID_ReturnEmployee()
        {
            Employee result = _sut.GetItemByIdAsync(2).Result;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Employee>());
            Assert.That(result.FirstName, Is.EqualTo("Thomas"));
        }

        [Test]
        public void GetAllItems_ShouldGetAllItems()
        {
            var result = _sut.GetAllItems();
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<Employee>>());

        }

        [Test]
        public void RemoveItemAsync_ShouldRemoveTheItem()
        {
            int originalNumOfEmpoyee = _sut.GetAllItems().Count;
            _sut.RemoveItemAsync(employeesCollection.employeesList[4]).Wait();
            int result = _sut.GetAllItems().count;
            Assert.That(result, Is.EqualTo(originalNumOfEmpoyee - 1));
        }

        //teardown

    }
}