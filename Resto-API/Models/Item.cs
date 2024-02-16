using Resto_API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_item")]
    public class Item : GeneralAttribute
    {
        [Column("name")]
        public string ItemName { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("stock")]
        public int Stock { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("Category")]
        public Category Category { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
