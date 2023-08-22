using Blog_ASP.Net_Core_6.Data;
using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_ASP.Net_Core_6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private IConfiguration _config;
        private readonly ILoginRepository _loginRepository;

        public LoginController(/*IConfiguration config,*/ ILoginRepository loginRepository)
        {
           // _config = config;
            _loginRepository = loginRepository;
        }
       
       
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _loginRepository.Authenticate(userLogin);

            if (user != null)
            {
                var token = _loginRepository.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

     

    }
}
