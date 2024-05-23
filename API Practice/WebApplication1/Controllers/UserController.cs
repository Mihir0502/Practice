using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.Repos;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userrepo;

        public UserController(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _userrepo.GetAllUser();
            return Ok(user);
        }
    }
}
