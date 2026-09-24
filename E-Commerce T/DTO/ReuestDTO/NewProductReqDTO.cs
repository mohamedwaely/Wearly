using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class NewProductReqDTO
    {
        [Required, MinLength(8), MaxLength(50)]
        public string name { get; set; }
        [Required, MinLength(15), MaxLength(10)]
        public string description { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string category { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string brand { get; set; }
        [Required, MinLength(1)]
        public List<ProductVariant> variants { get; set; }

    }

    public class ProductVariant
    {

        [Required, Range(0, double.MaxValue)]
        public decimal price { get; set; }
        [Required, Range(0, int.MaxValue)]
        public long quantity { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string color { get; set; }
        [Required, MinLength(1)]
        public string size { get; set; }
        public decimal? discountPercentage { get; set; }
        public DateTime? discountStartDate { get; set; }
        public DateTime? dicountEndDate { get; set; }
        [Required]
        public bool isActive { get; set; }

    }
}
