using BussinessLayer.repo;
using GlobalEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBC _employeeBC;
        public EmployeeController(IEmployeeBC employeeBC)
        {
            _employeeBC = employeeBC;
        }
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(tblEmployee employee)
        {
            string result = await _employeeBC.Save(employee);
            if (result.ToLower() == "saved")
                return Ok("Employee Created");
            else
                return BadRequest("somthing wrong");
        }
        [HttpPost]
        [Route("UpdateEmployee")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee(tblEmployee employee)
        {
            string result = await _employeeBC.Modify(employee);
            if (result.ToLower() == "updated")
                return Ok("Employee Updated");
            else
                return BadRequest("somthing wrong");
        }
        [HttpPost]
        [Route("RemoveEmployee")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            string result = await _employeeBC.RemoveEmployee(id);
            if (result.ToLower() == "deleted")
                return Ok("Employee Removed");
            else
                return BadRequest("somthing wrong");
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int empid)
        {
            tblEmployee emplist = new tblEmployee();

            emplist = await _employeeBC.GetEmployeeById(empid);
            return Ok(emplist);
        }
        [HttpGet]
        [Route("GetEmployeeByEmail")]
        public async Task<IActionResult> GetEmployeeByEmail(string emailid)
        {
            tblEmployee emplist = new tblEmployee();

            emplist = await _employeeBC.GetEmployeeByEmailId(emailid);
            return Ok(emplist);
        }
        [HttpGet]
        [Route("AllEmployee")]
        [Authorize]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<tblEmployee> emplist = new List<tblEmployee>();

            emplist = await _employeeBC.GetAllEmployee();
            return Ok(emplist);
        }

    }
}
