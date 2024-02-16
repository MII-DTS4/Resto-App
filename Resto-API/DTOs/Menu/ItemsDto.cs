using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Menu
{
    public class ItemsDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }

        public static explicit operator ItemsDto(Item item)
        {
            return new ItemsDto
            {
                Guid = item.Guid,
                Name = item.ItemName,
                Price = item.Price,
                Stock = item.Stock,
                Image = item.Image,
                Category = item.Category

            };
        }

        public static Item ConvertToItem(ItemsDto itemDto, Item item)
        {

            item.ItemName = itemDto.Name;
            item.Price = itemDto.Price;
            item.Stock = itemDto.Stock;
            item.Image = itemDto.Image;
            item.ModifiedDate = DateTime.Now;
            return item;
               
        }

    }
}
