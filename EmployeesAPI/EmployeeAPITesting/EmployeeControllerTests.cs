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
using Moq;
using EmployeesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPITesting
{
    public class EmployeeControllerTests
    {

        private Mock<IRepository<Employee>> _context;
        private EmployeesController _sut;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _context = new Mock<IRepository<Employee>>();
            TestEmpolyeesDataSource.EmployeesList.ForEach(e => _context.Setup(x => x.CreateItemAsync(e)));
            _sut = new EmployeesController(_context.Object);
        }

        [Test]
        public void EmpolyeesControllerSuccessfulConstruction()
        {
            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
        }

        [Test]
        public void PutEmployee_GivenAInvalidId_ReturnsBadRequest()
        {
            Employee employee = new Employee() { LastName = "Dodsworth", FirstName = "Annie", Title = "Sales Representative", Region = "WA" };
            var result = _sut.PutEmployee(10, employee);
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<BadRequestResult>());;
        }
        [Test]
        public void PutEmployee_GivenAValidId_ReturnCreated()
        {
            //var Getemployeename = _sut.GetByName();
            //Assert.That(Getemployeename.IsCompleted);
        }
    }
}
