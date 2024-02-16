using Resto_API.Models;
using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Menu
{
    public class CreateMenuDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }

        public static implicit operator Item(CreateMenuDto dto)
        {
            return new Item
            {
                Guid = Guid.NewGuid(),
                ItemName = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Image = dto.Image,
                Category = dto.Category,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}
