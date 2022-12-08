using System.ComponentModel.DataAnnotations;

namespace MVC_CS_API.DTO
{
    public class AuthUserDTO
    {
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }
    }
}
