using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ResponseDTO
{
    public class NewProductVariantResDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public string color { get; set; }

        [Required]
        public string size { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public long quantity { get; set; }

        [Required]
        public bool IsActive { get; set; }


    }
}
