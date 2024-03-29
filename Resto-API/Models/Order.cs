﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_order")]
    public class Order : GeneralAttribute
    {
        [Column("customer_guid")]
        public Guid CustomerGuid { get; set; }
        [Column("item_guid")]
        public Guid ItemGuid { get; set; }
        [Column("total_item")]
        public int TotalItem { get; set; }
        [Column("total_price")]
        public int TotalPrice { get; set; }

        public Item? Item { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
