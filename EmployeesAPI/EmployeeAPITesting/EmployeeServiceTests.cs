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
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<EmployeeDTO>>());

        }

        [Test]
        public void CreateItemAsync_ShouldAddAnEmployeeItem()
        {
            int originalNumOfEmpoyee = _sut.GetAllItems().Count;
            System.Console.WriteLine(originalNumOfEmpoyee);
            Employee employee = new Employee() { EmployeeId = 15, FirstName = "Gaurav", LastName = "Dogra", Title = "CEO", Region = "WA" };
           
            _sut.CreateItemAsync(employee);
            int countAfterAdd = _sut.GetAllItems().Count;
            Assert.That(countAfterAdd, Is.EqualTo(originalNumOfEmpoyee + 1));
        }

        [Test]
        public void ItemExists_ShouldReturnFalseIfEmployeeNotExist()
        {
            var doesNotExist = _sut.ItemExists(70);
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
            //System.Console.WriteLine(originalNumOfEmpoyee);
            _sut.RemoveItemAsync(TestEmpolyeesDataSource.EmployeesList[0]).Wait();
            int countAfterRemove = _sut.GetAllItems().Count;
            System.Console.WriteLine(countAfterRemove);
            Assert.That(countAfterRemove, Is.EqualTo(originalNumOfEmpoyee - 1));
        }

        [TearDown]
        public void TearDown()
        {
            //Find a function to clear all items from _sut
            foreach (var employee in TestEmpolyeesDataSource.EmployeesList)
            {
                _sut.RemoveItemAsync(employee);
            }

        }

    }
}