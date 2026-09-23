using E_Commerce_T.DTO.ReuestDTO;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_T.Controllers
{
    [ApiController]
    [Route("/")]
    public class Register : ControllerBase
    {
        private RegisterService _registerService;
        public Register(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] RegisterReqDTO request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var res = await _registerService.RegisterNewUser(request);
                return Ok(res);

            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            
        } 

    }
}
