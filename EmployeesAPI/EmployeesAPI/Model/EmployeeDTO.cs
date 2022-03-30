using System;

namespace EmployeesAPI.Model
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
        public string? Region { get; set; }

        //Age from DateTime to int

    }
}
