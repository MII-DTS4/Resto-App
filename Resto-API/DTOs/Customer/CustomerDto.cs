using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTO.Accounts
{
    public class CustomerDto
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
