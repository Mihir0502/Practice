using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.Repos;
namespace WebApplication1.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userrepo;

        public UserController(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userrepo.GetUser();

            return Ok(user);
        }
        [HttpGet("{id}", Name ="UserById")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var user12= await _userrepo.GetUsers(id);
            if (user12 is null)
            {
                return NotFound();
            }
            return Ok(user12);
        }

        [HttpPost]

        public async Task<IActionResult> AddUser(User user)
        {
            var createdUser = await _userrepo.AddUser(user);

            return Ok(createdUser);
        }
    }
}
