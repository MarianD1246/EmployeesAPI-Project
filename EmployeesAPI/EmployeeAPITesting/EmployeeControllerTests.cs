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

        private Mock<IRepository<Employee>> _service;
        private EmployeesController _sut;
        [SetUp]
        public void Setup()
        {
            _service = new Mock<IRepository<Employee>>();
            _sut = new EmployeesController(_service.Object);
        }

        [Test]
        public void EmployeesControllerSuccessfulConstruction()
        {
            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
        }

        [Test]
        public void GetEmployee_ReturnAListOfEmployee_WhenQueryIsValid()
        {
            EmployeeDTO employee = new() { EmployeeId = 1, Name = "Dodsworth Annie", JobTitle = "Sales Representative" };
            List<EmployeeDTO> dtoList = new() { employee };
            _service.Setup(x => x.GetAllItems()).Returns(dtoList);
            var result = _sut.GetEmployee();
            Assert.That(result.IsCompleted);
            Assert.That(result, Is.InstanceOf<Task<ActionResult<IEnumerable<EmployeeDTO>>>>());
        }

        [Test]
        public void GetEmployee_DoesNotReturnAnEmployee_WhenQueryIsInvalid()
        {
            _service.Setup(x => x.GetAllItems());
            var result = _sut.GetEmployee();
            Assert.That(result.IsCompleted);
            _service.Verify(cs => cs.GetAllItems(), Times.Never);
            //Assert.That(result, Is.InstanceOf<BadRequestResult>()); 
        }

        [Test]
        public void PutEmployee_GivenAInvalidId_ReturnsBadRequest()
        {
            Employee employee = TestEmpolyeesDataSource.EmployeesList[1];
            var result = _sut.PutEmployee(101, employee);
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<BadRequestResult>());
            
        }
        [Test]
        public void PutEmployee_GivenAValidName_UpdatesEmplolyee()
        {
            Employee employee = new Employee() { EmployeeId = 1, LastName = "Dodsworth", FirstName = "Annie", Title = "Sales Representative", Region = "WA" };
            _service.Setup(e => e.GetItemByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);
            var result = _sut.PutEmployee(1, employee);
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<CreatedResult>());
            _service.Verify(cs => cs.GetItemByIdAsync(1), Times.Once);
            _service.Verify(cs => cs.SaveItemChangesAsync(), Times.Once);
        }

        [Test]
        public void PostEmployee_AddsAnEmployee_GivenValidInfo()
        {
            Employee employee = new Employee() { LastName = "Dodsworth", FirstName = "Annie", Title = "Sales Representative", Region = "WA" };
            var result = _sut.PostEmployee(Utilities.EmployeeToDTO(employee));
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<ActionResult<EmployeeDTO>>());
            Assert.That(result.Result.Result, Is.InstanceOf<CreatedAtActionResult>());
        }

        [Test]
        public void DeleteEmployee_GivenInvalidInvalid_ResultNotFound()
        {
            var result = _sut.DeleteEmployee(10);
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void DeleteEmployee_GivenValidId_DeleteEmpoyee()
        {
            Employee employee = new Employee() { EmployeeId = 1, LastName = "Dodsworth", FirstName = "Annie", Title = "Sales Representative", Region = "WA" };
            _service.Setup(e => e.GetItemByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);
            var result = _sut.DeleteEmployee(10);
            Assert.That(result.IsCompleted);
            Assert.That(result.Result, Is.InstanceOf<NoContentResult>());
        }
    }
}
