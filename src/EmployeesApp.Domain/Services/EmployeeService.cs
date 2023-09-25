using EmployeesApp.Domain.Interfaces;
using EmployeesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Add(Employee employee)
        {
            await _employeeRepository.Add(employee);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<bool> Remove(Employee employee)
        {
            await _employeeRepository.Remove(employee);
            return true;
        }

        public async Task<IEnumerable<Employee>> Search(string fullName)
        {
            return await _employeeRepository.Search(e => e.FullName.Contains(fullName));
        }

        public async Task<Employee> Update(Employee employee)
        {
            if (!_employeeRepository.Search(e => e.Id == employee.Id).Result.Any())
                return null;

            await _employeeRepository.Update(employee);

            return employee;
        }

        public void Dispose()
        {
            _employeeRepository.Dispose();
        }

    }
}
