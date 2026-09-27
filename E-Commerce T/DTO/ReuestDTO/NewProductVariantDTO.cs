using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class NewProductVariantDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public long productId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal price { get; set; }

        [Required, Range(0, int.MaxValue)]
        public long quantity { get; set; }

        [Required]
        public long colorId { get; set; }

        [Required]
        public long sizeId { get; set; }
        public decimal? discountPercentage { get; set; }
        public DateTime? discountStartDate { get; set; }
        public DateTime? discountEndDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
