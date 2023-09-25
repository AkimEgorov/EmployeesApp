using AutoMapper;
using EmployeesApp.API.Dtos.Employee;
using EmployeesApp.Domain.Models;

namespace EmployeesApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeEditDto>().ReverseMap();
            CreateMap<Employee, EmployeeResultDto>().ReverseMap();
        }
    }
}
