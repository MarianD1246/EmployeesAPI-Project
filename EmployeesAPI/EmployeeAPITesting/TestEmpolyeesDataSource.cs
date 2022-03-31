using EmployeesAPI;
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
    }
}
