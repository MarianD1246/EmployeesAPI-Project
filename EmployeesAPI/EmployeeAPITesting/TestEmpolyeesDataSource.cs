using EmployeesAPI;
using System.Collections.Generic;

namespace EmployeeAPITesting
{
    public class TestEmpolyeesDataSource
    {
        

        public List<Employee> EmployeesList
        {
            get { return EmployeesList; }
            set
            {
                EmployeesList.Add(new Employee()
                {
                    EmployeeId = 1,
                    FirstName = "Bob",
                    LastName = "Smith",
                    Title = "Sales Manager",
                    Region = "WA"
                }),

                EmployeesList.Add(new Employee()
                {
                    EmployeeId = 2,
                    FirstName = "Thomas",
                    LastName = "Brut",
                    Title = "Sales",
                }),
                new Employee()
                {
                    EmployeeId = 3,
                    FirstName = "Cathy",
                    LastName = "Paris",
                    Title = "Sales Representative",
                };
                new Employee()
                {
                    EmployeeId = 4,
                    FirstName = "Simon",
                    LastName = "Kull",
                    Title = "Sales Representative",
                    Region = "WA"
                };
            }
        }    
    }
}
