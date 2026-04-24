using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PromoteUserDto
{
    [Required(ErrorMessage = "User id is required")]
    [RegularExpression(@".*\S.*", ErrorMessage = "User id cannot be whitespace")]
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required")]
    [RegularExpression("^(Admin|Seller|Stock|Customer)$", ErrorMessage = "Role is invalid")]
    public string Role { get; set; } = string.Empty;
}
