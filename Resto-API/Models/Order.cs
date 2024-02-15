using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    public class Order : GeneralAttribute
    {
        [Column("transaction_guid")]
        public Guid TransactionGuid { get; set; }
        [Column("item_guid")]
        public Guid ItemGuid { get; set; }
        [Column("total_item")]
        public int TotalItem { get; set; }
        [Column("total_price")]
        public int TotalPrice { get; set; }
        [Column("remarks")]
        public string? Remarks { get; set; }

        public Item? Item { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
