using EmployeeERP.Migrations;
using EmployeeERP.Models;
using EmployeeERP.Services.IServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeERP.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ModelStateDictionary _modelState;
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext, ModelStateDictionary modelState)
        {
            _applicationDbContext = applicationDbContext;
            _modelState = modelState;
        }

        public async Task<Employee> AddEmployee(Employee objEmployee)
        {
            try
            {
                bool nameExist = _applicationDbContext.Employees.Any(x => x.name == objEmployee.name);
                if (nameExist)
                {
                    string message = "name already exist";
                    return null;
                }
                _applicationDbContext.Employees.Add(objEmployee);
                await _applicationDbContext.SaveChangesAsync();
                return objEmployee;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<int> DeletePEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployee(int? postId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(Employee employee)
        {

            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                if (_applicationDbContext !=null)
                {
                    return await _applicationDbContext.Employees.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool ValidateEmployee(Employee employee)
        {
            bool nameExist = _applicationDbContext.Employees.Any(x=>x.name == employee.name);
            if (employee.name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (nameExist == true)
            {
                _modelState.AddModelError("Name", "Name already exist");
            }
            return _modelState.IsValid;
        }
    }
}
