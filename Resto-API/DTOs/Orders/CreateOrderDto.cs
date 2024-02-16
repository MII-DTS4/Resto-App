
namespace Resto_API.DTOs.Wishlist
{
using Resto_API.Models;
    public class CreateOrderDto
    {
        public Guid ItemGuid { get; set; }
        public Guid TransactionGuid { get; set; }
        public int TotalItem { get; set; }
        public int TotalPrice { get; set; }

        public static explicit operator Order (CreateOrderDto createOrderDto)
        {
            return new Order
            {
                Guid = Guid.NewGuid(),
                ItemGuid = createOrderDto.ItemGuid,
                TransactionGuid = createOrderDto.TransactionGuid,
                TotalItem = createOrderDto.TotalItem,
                TotalPrice = createOrderDto.TotalPrice,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }

    }
}
