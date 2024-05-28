using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        // return all data of employee
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //var arar = await _employeeRepo.GetEmployees();
            //return Ok(arar);
            return await _employeeRepo.GetEmployees();

        }

        [HttpGet]
        public string GetEmployeeName()
        {
            return "mihir";
        }

        // return data of employee that is specified by id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var employee = await _employeeRepo.GetEmployeeById(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // add employee karega !!

        [HttpPost]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            await _employeeRepo.AddEmployee(employee);
            return Ok("added");

        }

        // delete employee method

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var employee = _employeeRepo.GetEmployeeById(id);
        //    if (employee == null)
        //    {  return NotFound(); }
            
        //}




    }
}
