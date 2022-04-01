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
            foreach (var employee in TestEmpolyeesDataSource.EmployeesList)
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
            Assert.That(result, Is.TypeOf<List<EmployeeDTO>>());

        }

        [Test]
        public void CreateItemAsync_ShouldAddAnEmployeeItem()
        {
            Employee employee = new Employee() { EmployeeId = 6, FirstName = "Gaurav", LastName = "Dogra", Title = "CEO", Region = "WA" };
            int originalNumOfEmpoyee = _sut.GetAllItems().Count;
            _sut.CreateItemAsync(employee).Wait();
            int countAfterAdd = _sut.GetAllItems().Count;
            Assert.That(countAfterAdd, Is.EqualTo(originalNumOfEmpoyee + 1));
        }

        [Test]
        public void ItemExists_ShouldReturnFalseIfEmployeeNotExist()
        {
            var doesNotExist = _sut.ItemExists(7);
            Assert.That(doesNotExist, Is.False);
        }
        
        [Test]
        public void ItemExists_ShouldReturnTrueIfEmployeeExist()
        {
            var doesNotExist = _sut.ItemExists(1);
            Assert.That(doesNotExist, Is.True);
        }

        [Test]
        public void RemoveItemAsyncByItem_ShouldRemoveTheItem()
        {
            int originalNumOfEmpoyee = _sut.GetAllItems().Count;
            _sut.RemoveItemAsync(TestEmpolyeesDataSource.EmployeesList[3]).Wait();
            int countAfterRemove = _sut.GetAllItems().Count;
            Assert.That(countAfterRemove, Is.EqualTo(originalNumOfEmpoyee - 1));
        }

        [TearDown]
        public void TearDown()
        {
            //Find a function to clear all items from _sut
            foreach(var item in _sut.GetAllItems())
            {
                //_sut.RemoveItemAsync(item);
            }
        }

    }
}