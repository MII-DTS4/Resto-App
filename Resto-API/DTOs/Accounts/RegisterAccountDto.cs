using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Accounts;

public class RegisterAccountDto : GeneralGuid
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public static implicit operator Account(RegisterAccountDto accDto)
    {
        return new Account
        {
            Guid = accDto.Guid,
            Password = accDto.Password,
            IsUsed = false,
            Otp = 0,
            ExpiredDate = DateTime.Now,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
    public static implicit operator Customer(RegisterAccountDto accDto)
    {
        return new Customer
        {
            FirstName = accDto.FirstName,
            LastName = accDto.LastName,
            Email = accDto.Email,
            PhoneNumber = accDto.PhoneNumber,
            Gender = accDto.Gender,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}