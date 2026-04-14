using Core.Entities;

namespace API.Dtos
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
