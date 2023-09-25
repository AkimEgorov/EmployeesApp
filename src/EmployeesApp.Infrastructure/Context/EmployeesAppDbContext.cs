using EmployeesApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Infrastructure.Context
{
    public class EmployeesAppDbContext : DbContext
    {
        public EmployeesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }


    }
}
