using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeesApp.API.Dtos.Employee
{
    public class EmployeeEditDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        public string? Department { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public int? Salary { get; set; }
    }
}
