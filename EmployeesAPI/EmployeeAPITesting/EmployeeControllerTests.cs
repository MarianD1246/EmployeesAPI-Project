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

        private Mock<NorthwindContext>? _context;
        private EmployeesController _sut;
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _context = new Mock<NorthwindContext>();
            _context.Setup(e => e.Employees.AddRange(TestEmpolyeesDataSource.EmployeesList.ToArray()));
            _sut = new EmployeesController(_context.Object);
        }

        [Test]
        public void EmpolyeesControllerSuccessfulConstruction()
        {
            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
        }

        [Test]
        public void GetById_GivenAValidId_ReturnsEmpolyee()
        {
            var getEmployeeById = _sut.GetById(1);
            Assert.That(getEmployeeById.IsCompleted);
            Assert.That(getEmployeeById.Result.Value, Is.InstanceOf<IEnumerable<EmployeeDTO>>());
            //var emp = getEmployeeById.Result.Value.ToList();
            //Assert.That(emp[0], Is.EqualTo(TestEmpolyeesDataSource.EmployeesList[0]));
            
            //var result = _sut.GetEmployeeById(0).Result;
            //Assert.That(result, Is.Not.Null);
            //Assert.That(result.Value, Is.TypeOf<Employee>());
            //Assert.That(result.Value.FirstName, Is.EqualTo("Bob"));
        }
        [Test]
        public void PutEmployee_GivenAValidName_ReturnsEmpolyee()
        {
            //var Getemployeename = _sut.GetByName();
            //Assert.That(Getemployeename.IsCompleted);
        }
    }
}
