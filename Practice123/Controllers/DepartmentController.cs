using Practice123.Models;
using Dapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace Practice123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly string _connectionString;

        public DepartmentController()
        {
            _connectionString = "Data Source=172.16.18.15;Initial Catalog=EmployeeManagement;MultipleActiveResultSets=True;TrustServerCertificate=True;Uid=hbits-mihir;password=lwC655E00lZh";
        }
        [HttpGet("GetDepartment")]
        public IActionResult GetDepartments()
        { 
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM tblDepartments";
                var departments = connection.Query<Department>(query);
                return Ok(departments);
            }
        }

        [HttpPost]
        public IActionResult InsertDepartment(Department dep)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "insert into tblDepartments (Id, Name, Location) values(@Id, @Name, @Location)";
                var result12 = connection.Execute(query, new { Id = dep.Id, Name = dep.Name, Location = dep.Location });
                //var result12 = connection.Execute(query, dep);
                return Ok(result12);
            }
        }

        [HttpPost("DeleteDepartment")]
        public IActionResult DeleteDepartment(int departmentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM tblDepartments WHERE Id = @Id";
                connection.Execute(query, new { Id = departmentId });
            }
            return Ok("Deleted successfully.");
        }

        [HttpPost("UpdateDepartment")]
        public IActionResult UpdateDepartment(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string qurey = "update tblDepartments set Name = @Name, Location=@Location, Where Id= @Id";
                connection.Execute(qurey, new { Id = department.Id, Name = department.Name, Location = department.Location });
            }
            return Ok("Updated Details");
        }
    }
}
