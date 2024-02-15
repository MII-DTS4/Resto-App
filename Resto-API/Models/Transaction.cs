using System.ComponentModel.DataAnnotations.Schema;

namespace Resto_API.Models
{
    [Table("tb_m_transaction")]
    public class Transaction : GeneralAttribute
    {
        public Guid CustomerGuid { get; set; }
        public int PriceTransaction { get; set; }
        public 
    }
}
