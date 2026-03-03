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
        public string FullName {  get; set; } = string.Empty;
        [Required]
        public required string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Country { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsDefault { get; set; } = false;
    }
}
