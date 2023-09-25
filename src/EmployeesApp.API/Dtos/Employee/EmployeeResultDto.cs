using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.API.Dtos.Employee
{
    public class EmployeeResultDto
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Department { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public int? Salary { get; set; }
    }
}
