using EmployeesAPI;
using EmployeesAPI.Services;
using NUnit.Framework;

namespace EmployeeAPITesting
{
    public class EmployeeServiceTests
    {
        private NorthwindContext? _context;
        private EmployeeService? _sut;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}