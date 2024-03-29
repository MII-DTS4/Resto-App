﻿using Resto_API.DTOs;
using Resto_API.Models;

namespace Resto_API.DTOs.Accounts
{
    public class AccountDto : GeneralGuid
    {
        // atribut yang ingin ditampilkan dan diisi oleh User
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUsed { get; set; }
        public int Otp { get; set; }
        public DateTime ExpiredDate { get; set; }

        public static explicit operator AccountDto(Account acc)
        {

            return new AccountDto
            {
                Guid = acc.Guid,
                Password = acc.Password,
                IsUsed = acc.IsUsed,
                Otp = acc.Otp,
                ExpiredDate = acc.ExpiredDate
            };
        }

        public static implicit operator Account(AccountDto accDto)
        {
            return new Account
            {
                Guid = accDto.Guid,
                Password = accDto.Password,
                IsUsed = accDto.IsUsed,
                Otp = accDto.Otp,
                ExpiredDate = accDto.ExpiredDate,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
        
    }
}
