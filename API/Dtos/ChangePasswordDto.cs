using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Current password is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "Current password cannot be whitespace")]
        public required string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "New password cannot be whitespace")]
        public required string NewPassword { get; set; }
    }
}
