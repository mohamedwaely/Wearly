using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class NewCartItemReq
    {
        [Required]
        public long cartId { get; set; }

        [Required]
        public long productVariantId { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int quantity { get; set; }
    }
}
