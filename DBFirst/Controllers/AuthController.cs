using BussinessLayer.repo;
using GlobalEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBC _loginBC;
        private readonly IConfiguration _config;
        public AuthController(ILoginBC loginBC, IConfiguration config)
        {
            _loginBC = loginBC;
            _config = config;
        }

        #region User Regstration

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(tblEmployeeLogin login)
        {
            string result = await _loginBC.CreateUser(login);
            if (result.ToLower() == "saved")
                return Ok("Registraion Done");
            else
                return BadRequest("somthing wrong");
        }
        
        [HttpPost]
        [Route("RemoveUser")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            string result = await _loginBC.RemoveUser(id);
            if (result.ToLower() == "deleted")
                return Ok("User Removed");
            else
                return BadRequest("somthing wrong");
        }
        
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int empid)
        {
            tblEmployeeLogin emplist = new tblEmployeeLogin();

            emplist = await _loginBC.GetUserById(empid);
            return Ok(emplist);
        }
        
        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<tblEmployeeLogin> emplist = new List<tblEmployeeLogin>();

            emplist = await _loginBC.GetAllUser();
            return Ok(emplist);
        }
        
        #endregion

        #region User Token validation

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(tblUser login)
        {
            string result = await _loginBC.validateuser(login.EmailId, login.Password);
            if (result.ToLower() == "valid")
            {
                var token = GenToken(login);
                return Ok(new { token = token });
            }
            else
                return BadRequest("somthing wrong");

        }
        private string GenToken(tblUser login)
        {
            var serutikey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(serutikey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
