using EmployeesApp.Domain.Interfaces;
using EmployeesApp.Domain.Models;
using EmployeesApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesAppDbContext context) : base(context) { }
    }
}
