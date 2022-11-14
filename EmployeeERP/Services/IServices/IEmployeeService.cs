using EmployeeERP.Models;
using Microsoft.Extensions.Hosting;

namespace EmployeeERP.Services.IServices
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int? postId);

        Task<Employee> GetEmployee(Employee employee);
        Task<int> DeletePEmployee(int? id);

        Task UpdateEmployee(Employee employee);

        Task<Employee> AddEmployee(Employee objEmployee);
    }
}
