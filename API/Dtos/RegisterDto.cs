using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "First name cannot be whitespace")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Last name cannot be whitespace")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Password cannot be whitespace")]
        public string Password { get; set; } = string.Empty;
    }
}
