using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitorApi.Models.ApiModels;
using SitorApi.Security;

namespace SitorApi.Controllers.DBControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuthenticationManger _jwtAuthenticationManger;


        public LoginController(IJwtAuthenticationManger jwtAuthenticationManger)
        {
            _jwtAuthenticationManger = jwtAuthenticationManger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserModel userCred)
        {
            var token = _jwtAuthenticationManger.Authenticate(userCred.UserName, userCred.Password);
            if (token != null)
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
