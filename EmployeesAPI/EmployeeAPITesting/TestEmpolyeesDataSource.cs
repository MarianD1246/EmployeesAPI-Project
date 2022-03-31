using EmployeesAPI;
using EmployeesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPITesting
{
    public class TestEmpolyeesDataSource
    {
        public List<Employee> employee = new()
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
