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
    }
}

