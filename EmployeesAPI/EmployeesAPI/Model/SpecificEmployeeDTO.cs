namespace EmployeesAPI.Model
{
    public class SpecificEmployeeDTO
    { 
            public int EmployeeId { get; set; }
            public string Name { get; set; } = null!;
            public string? JobTitle { get; set; }
            public string? FullAddress { get; set; }
            public string? PhoneNumber { get; set; }
            public string? WorkExtension { get; set; }
            public DateTime? HireDate { get; set; }
            public string? Notes { get; set; }

    }
}
