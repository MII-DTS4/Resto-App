using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class MenuRepository : GeneralRepository<Item> , IMenuRepository
    {
        public MenuRepository(RestoAppDbContext context) : base(context)
        {
        }
    }
}
