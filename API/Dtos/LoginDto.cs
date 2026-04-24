using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Password cannot be whitespace")]
        public string Password { get; set; } = string.Empty;
    }
}
