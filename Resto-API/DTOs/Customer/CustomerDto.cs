using Resto_API.DTOs.Accounts;
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

        public static implicit operator Customer(CustomerDto accDto)
        {
            return new Customer
            {
                Guid = accDto.Guid,
                FirstName = accDto.FirstName,
                LastName = accDto.LastName,
                Gender = accDto.Gender,
                Email = accDto.Email,
                PhoneNumber = accDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }   
}
