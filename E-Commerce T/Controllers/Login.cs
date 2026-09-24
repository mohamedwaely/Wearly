using E_Commerce_T.DTO.ReuestDTO;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_T.Controllers
{
    [ApiController]
    [Route("auth")]
    public class Login : ControllerBase
    {
        private readonly LoginService _loginService;
        public Login(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginController([FromBody] LoginReqDTO req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var res = await _loginService.loginS(req);
                return Ok(res);

            }
            catch(UnauthorizedAccessException exp)
            {
                return BadRequest(new { message = exp.Message });

            }


        }

    }
}
