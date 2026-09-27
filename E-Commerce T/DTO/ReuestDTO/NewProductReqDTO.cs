using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class NewProductReqDTO
    {
        [Required, MinLength(8), MaxLength(50)]
        public string name { get; set; }
        [Required, MinLength(15), MaxLength(500)]
        public string description { get; set; }
        [Required]
        public long categoryId { get; set; }
        [Required]
        public long brandId { get; set; }

    }

}
