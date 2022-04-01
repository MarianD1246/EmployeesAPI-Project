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
                Name = $"{employee.TitleOfCourtesy} {employee.FirstName} {employee.LastName}",
                JobTitle = employee.Title,
                FullAddress = $"{employee.Address},{employee.City},{employee.PostalCode},{employee.Region},{employee.Country}",
                PhoneNumber = employee.HomePhone,
                WorkExtension = employee.Extension,
                HireDate = employee.HireDate,
                Notes = employee.Notes,
            };
        }

        //There is a mapper that does this automatically (look for it if we get time)
        public static Employee DTOToEmployee(EmployeeDTO employee)
        {
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                Title = employee.Name.Split(' ')[0],
                FirstName = employee.Name.Split(' ')[1],
                LastName = employee.Name.Split(' ')[2],
                Address = employee.FullAddress.Split(',')[0],
                City = employee.FullAddress.Split(',')[1],
                PostalCode = employee.FullAddress.Split(',')[2],
                Region = employee.FullAddress.Split(',')[3],
                Country = employee.FullAddress.Split(',')[4],
                Extension = employee.WorkExtension,
                HomePhone = employee.PhoneNumber,
                HireDate = employee.HireDate,
                Notes = employee.Notes,
            };
        }

    }
}

