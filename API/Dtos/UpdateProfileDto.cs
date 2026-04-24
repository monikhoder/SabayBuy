using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateProfileDto
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "First name cannot be whitespace")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "Last name cannot be whitespace")]
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
