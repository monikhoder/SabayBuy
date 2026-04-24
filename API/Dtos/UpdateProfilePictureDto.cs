using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateProfilePictureDto
    {
        [Required(ErrorMessage = "Profile URL is required")]
        [RegularExpression(@".*\S.*", ErrorMessage = "Profile URL cannot be whitespace")]
        public required string ProfileUrl { get; set; }
    }
}
