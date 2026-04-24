using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AddressDto
    {
        public Guid? Id { get; set; }
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Full name cannot be whitespace")]
        public string FullName {  get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Address line 1 cannot be whitespace")]
        public required string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Phone number cannot be whitespace")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "City cannot be whitespace")]
        public string City { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "State cannot be whitespace")]
        public string State { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Zip code cannot be whitespace")]
        public string ZipCode { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@".*\S.*", ErrorMessage = "Country cannot be whitespace")]
        public string Country { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
