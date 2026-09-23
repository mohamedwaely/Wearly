using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class LoginReqDTO
    {
        [Required, EmailAddress]
        public string email { get; set; }

        [Required, MinLength(8)]
        public string password { get; set; }
    }
}
