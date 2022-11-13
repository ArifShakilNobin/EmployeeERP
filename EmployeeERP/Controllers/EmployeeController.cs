using EmployeeERP.Migrations;
using EmployeeERP.Models;
using EmployeeERP.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService= _employeeService;
        }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeService.GetEmployees();
                if (employees ==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employees);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = await employeeService.AddEmployee(model);
                    if (employee.id == 0)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                    }
                    return Ok("Added Successfully");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return BadRequest();
        }


    }
}
