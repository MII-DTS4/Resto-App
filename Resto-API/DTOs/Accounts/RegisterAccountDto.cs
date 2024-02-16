using Resto_API.DTO.Accounts;
using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace API.DTOs.Accounts;

public class RegisterCustDto
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    //public static implicit operator Customer(CustomerDto CreateDto)
    //{
    //    // setelah method dipanggil akan otomatis konversi isi atribut
    //    // konversi DTO ke Model agar dapat di Insert oleh Repository-Model
    //    return new Customer
    //    {
    //        Guid = Guid.NewGuid(),
    //        FirstName = CreateDto.FirstName,
    //        LastName = CreateDto.LastName,
    //        Gender = CreateDto.Gender,
    //        Email = CreateDto.Email,
    //        Address = CreateDto.Email,
    //        PhoneNumber = CreateDto.PhoneNumber,
    //        CreatedDate = DateTime.Now,
    //        ModifiedDate = DateTime.Now
    //    };
    //}
}