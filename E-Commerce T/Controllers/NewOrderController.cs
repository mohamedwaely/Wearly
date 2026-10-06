using E_Commerce_T.Extensions;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace E_Commerce_T.Controllers
{
    [ApiController]
    [Route("order")]
    public class NewOrderController:ControllerBase
    {
        private NewOrderService _newOrderService;
        public NewOrderController(NewOrderService newOrderService)
        {
            _newOrderService = newOrderService;
        }

        [HttpPost]
        [Authorize]
        [Route("make")]
        public async Task<IActionResult> placeOrder()
        {
            //var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            //if(userIdClaim is null)
            //{
            //    return Unauthorized();
            //}

            
            try
            {
                long userId = User.GetUserId();
                var res = await _newOrderService.makeOrder(userId);
                return Ok(res);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            



        }
    }
}
