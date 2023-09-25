using EmployeesApp.Domain.Interfaces;
using EmployeesApp.Domain.Services;
using EmployeesApp.Infrastructure.Context;
using EmployeesApp.Infrastructure.Repositories;

namespace EmployeesApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<EmployeesAppDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
