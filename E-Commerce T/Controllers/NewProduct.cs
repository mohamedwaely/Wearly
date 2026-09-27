using E_Commerce_T.DTO.ReuestDTO;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_T.Controllers
{
    [ApiController]
    [Route("/products")]
    public class NewProduct : ControllerBase
    {

        private NewProductService _newProductService;
        public NewProduct(NewProductService newProductService)
        {
            _newProductService = newProductService;
        }

        [HttpPost("new")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> NewProductApi([FromBody]NewProductReqDTO req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var product = await _newProductService.AddNewProduct(req);
                return Ok(product);

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
