using E_Commerce_T.DTO.ReuestDTO;
using E_Commerce_T.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_T.Controllers
{
    [ApiController]
    [Route("productvariant")]
    public class NewProductVariant : ControllerBase
    {
        private NewProductVariantService _newProductVariantService;
        public NewProductVariant(NewProductVariantService newProductVariantService)
        {
            _newProductVariantService = newProductVariantService;
        }

        [HttpPost("new")]
        public async Task<IActionResult> NewProductVariantController([FromBody]NewProductVariantDTO req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var res = await _newProductVariantService.AddProductVariant(req);
                return Ok(res);

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }


        }

    }
}
