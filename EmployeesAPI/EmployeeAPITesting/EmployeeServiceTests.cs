using EmployeesAPI;
using EmployeesAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using Microsoft.Data.Sqlite;
using EmployeesAPI.Model;
using EmployeesAPI.Controllers;

namespace EmployeeAPITesting
{
    public class EmployeeServiceTests
    {
        private NorthwindContext? _context;
        private EmployeeService? _sut;


        [Test]
        public void CorrectConstruction()
        {
            var mockService = new Mock<NorthwindContext>();
            _sut = new EmployeeService(mockService.Object);
            Assert.That(_sut, Is.InstanceOf<EmployeeService>());
        }
    }
}