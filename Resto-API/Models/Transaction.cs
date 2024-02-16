using Resto_API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_transaction")]
    public class Transaction : GeneralAttribute
    {
        [Column("customer_guid")]
        public Guid CustomerGuid { get; set; }
        [Column("price_transaction")]
        public int PriceTransaction { get; set; }
        [Column("status")]
        public StatusLevel Status { get; set; }
        [Column("invoice")]
        public string Invoice { get; set; }
        [Column("remarks")]
        public string? Remarks { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Customer? Customer { get; set; }
    }
}
