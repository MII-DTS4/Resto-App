﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_accounts")]
    public class Account : GeneralAttribute
    {
        [Column("password")]
        public string Password { get; set; }
        [Column("otp")]
        public int Otp { get; set; }
        [Column("is_used")]
        public bool IsUsed { get; set; }
        [Column("expired_date")]
        public DateTime ExpiredDate { get; set; }

        public Customer? Customer { get; set; }
        public  ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
