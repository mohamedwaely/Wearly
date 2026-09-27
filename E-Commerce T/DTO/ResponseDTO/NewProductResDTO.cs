using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ResponseDTO
{
    public class NewProductResDTO
    {
        [Required]
        public long id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string BaseCategory { get; set; }
        [Required]
        public string subCategory { get; set; }
        
        [Required]
        public string brand { get; set; }

    }
}
