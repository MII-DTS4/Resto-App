
namespace Resto_API.DTOs.Wishlist
{
using Resto_API.Models;
    public class CreateOrderDto
    {
        public Guid ItemGuid { get; set; }
        public Guid CustomerGuid { get; set; }
        public int TotalItem { get; set; }
        public int TotalPrice { get; set; }

        public static explicit operator Order (CreateOrderDto createOrderDto)
        {
            return new Order
            {
                Guid = Guid.NewGuid(),
                ItemGuid = createOrderDto.ItemGuid,
                CustomerGuid = createOrderDto.CustomerGuid,
                TotalItem = createOrderDto.TotalItem,
                TotalPrice = createOrderDto.TotalPrice,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }

    }
}
