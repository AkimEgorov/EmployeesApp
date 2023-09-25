using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Models
{
    public class Employee : Entity
    {
    
        [StringLength(100)]
        public string? FullName { get; set; }

        [StringLength(50)]
        public string? Department { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EmploymentDate { get; set; }

        public int? Salary { get; set; }

    }
}
