using EmployeesAPI;
using EmployeesAPI.Model;
using System.Collections.Generic;

namespace EmployeeAPITesting
{
    public static class TestEmpolyeesDataSource
    {
        public static List<Employee> EmployeesList { get; set; } = new List<Employee>()
        {
            new Employee()
            {
                EmployeeId = 1,
                FirstName = "Bob",
                LastName = "Smith",
                Title = "Sales Manager",
                Region = "WA"
            },
            new Employee()
            {
                EmployeeId = 2,
                FirstName = "Thomas",
                LastName = "Brut",
                Title = "Sales",
            },
            new Employee()
            {
                EmployeeId = 3,
                FirstName = "Cathy",
                LastName = "Paris",
                Title = "Sales Representative",
            },
            new Employee()
            {
                EmployeeId = 4,
                FirstName = "Simon",
                LastName = "Kull",
                Title = "Sales Representative",
                Region = "WA"
            }
        };

        public static List<EmployeeDTO> EmployeesListDTO { get; set; } = new List<EmployeeDTO>()
        {
            new EmployeeDTO()
            {
                EmployeeId = 1,
                Name = "Bob Smith",
                JobTitle = "Sales Manager"
            },
            new EmployeeDTO()
            {
                EmployeeId = 2,
                Name = "Thomas Brut",
                JobTitle = "Sales"
            },
            new EmployeeDTO()
            {
                EmployeeId = 3,
                Name = "Cathy Paris",
                JobTitle = "Sales Representative"
            },
            new EmployeeDTO()
            {
                EmployeeId = 4,
                Name = "Simon Kull",
                JobTitle = "Sales Representative"
            }
        };
    }
}
