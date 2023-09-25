using EmployeesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        
    }
}
