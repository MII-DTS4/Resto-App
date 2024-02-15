using Resto_API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_transaction")]
    public class Transaction : GeneralAttribute
    {
        [Column("customer_guid")]
        public Guid CustomerGuid { get; set; }
        [Column("order_guid")]
        public Guid OrderGuid { get; set; }
        [Column("price_transaction")]
        public int PriceTransaction { get; set; }
        [Column("status")]
        public StatusLevel Status { get; set; }
        [Column("invoice")]
        public string Invoice { get; set; }

        public Order? Order { get; set; }
        public Customer? Customer { get; set; }
    }
}
