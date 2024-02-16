using Resto_API.Utilities.Enums;

namespace Resto_API.DTOs.Menu
{
    public class ItemsDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
