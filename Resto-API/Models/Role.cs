using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_roles")]
    public class Role : GeneralAttribute
    {
        [Column("role_name", TypeName = "nvarchar(50)")]
        public string RoleName { get; set; }

        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
