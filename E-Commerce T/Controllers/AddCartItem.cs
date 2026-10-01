using E_Commerce_T.DTO.ReuestDTO;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_T.Controllers
{

    [ApiController]
    [Route("cart")]
    public class AddCartItem : ControllerBase
    {

        private NewCartItemService _cartItemService;
        public AddCartItem (NewCartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddNItem([FromBody] NewCartItemReq req)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var res = await _cartItemService.AddCartItem(req);
                return Ok(res);

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }

    }
}
