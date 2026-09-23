using System.ComponentModel.DataAnnotations;

namespace E_Commerce_T.DTO.ReuestDTO
{
    public class RegisterReqDTO
    {
        [Required, EmailAddress]
        public string email;

        [Required, MinLength(3), MaxLength(20)]
        public string username;

        [Required, MinLength(8)]
        public string password;
    }
}
