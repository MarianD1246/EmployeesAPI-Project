using EmployeesAPI.Model;

namespace EmployeesAPI.Services
{
    public static class Utilities
    {
        public static EmployeeDTO EmployeeToDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                Region = employee.Region,
                City = employee.City,

            };
        }

        //There is a mapper that does this automaticly (look for it if we get time)
        public static Employee DTOToEmployee(EmployeeDTO employee)
        {
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                Region = employee.Region,
                City = employee.City,
            };
        }

    }
}

