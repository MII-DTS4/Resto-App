﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_account_roles")]
    public class AccountRole : GeneralAttribute
    {
        [Column("account_guid")]
        public Guid AccountGuid { get; set; }
        [Column("role_guid")]
        public Guid RoleGuid { get; set; }

        public Account? Account { get; set; }
        public Role? Role { get; set; }
    }
}
