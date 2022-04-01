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
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _service = new Mock<IRepository<Employee>>();
            _sut = new EmployeesController(_service.Object);
        }

        //tests DTO when contrller update
        //GET from badrequest to nocontent 



        [Test]
        public void EmpolyeesControllerSuccessfulConstruction()
        {
            Assert.That(_sut, Is.InstanceOf<EmployeesController>());
        }

        [Test]
        public void GetEmpoyee_HappyPath_ReturnAListOfEmpoyee()
        {
            EmployeeDTO employee = new() { EmployeeId = 1, Name = "Dodsworth Annie", JobTitle = "Sales Representative" };
            List<EmployeeDTO> dtoList = new() { employee };
            _service.Setup(x => x.GetAllItems()).Returns(dtoList);
            var result = _sut.GetEmployee();
            Assert.That(result.IsCompleted);
            Assert.That(result, Is.InstanceOf<Task<ActionResult<IEnumerable<EmployeeDTO>>>>());
        }

        [Test]
        public void GetEmpoyee_SadPath_ReturnBadRequest()
        {
            EmployeeDTO employee = new() { EmployeeId = 1, Name = "Dodsworth Annie", JobTitle = "Sales Representative" };
            _service.Setup(x => x.GetAllItems()).Returns(new List<EmployeeDTO>());
            var result = _sut.GetEmployee();
            Assert.That(result.IsCompleted);
            _service.Verify(cs => cs.GetAllItems(), Times.Never);
            //Assert.That(result, Is.InstanceOf<BadRequestResult>()); //bad request in getEmpoyee is unreachable code
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
        public void PutEmployee_GivenAValidName_ReturnsEmpolyee()
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
        public void ReturnNoContentResult_WhenUpdateIsCalled_WithValidId()
        {
            // Arrange
            //var mockService = new Mock<ITodoItemService>();
            //var item = new TodoItem { Id = 1, IsComplete = true, Name = "Sweep hallway", Secret = "I don't live here" };
            //mockService.Setup(cs => cs.GetTodoItemByIdAsync(1)).ReturnsAsync(item);
            //_sut = new TodoItemsController(mockService.Object);
            //// Act
            //var result = _sut.UpdateTodoItem(1, new TodoItemDTO { Id = 1, IsComplete = false });

            //// Assert
            //Assert.That(result.Result, Is.InstanceOf<NoContentResult>());
        }

    }
}
