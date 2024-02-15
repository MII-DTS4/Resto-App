using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_customer")]
    public class Customer : GeneralAttribute
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("email")]
        public string Email { get; set; }
        //[Column("gender")]
        //public Gender Gender { get; set; }
    }
}
