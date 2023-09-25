using EmployeesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetById(int id);

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);

        Task<bool> Remove(Employee employee);

        Task<IEnumerable<Employee>> Search(string fullName);
    }
}
