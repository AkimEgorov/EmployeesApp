using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.API.Dtos.Employee
{
    public class EmployeeAddDto
    {
        [Required]
        public string? FullName { get; set; }

        public string? Department { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public int? Salary { get; set; }
    }
}
