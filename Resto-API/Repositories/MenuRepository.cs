using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class MenuRepository : GeneralRepository<Item>
    {
        protected MenuRepository(RestoAppDbContext context) : base(context)
        {
        }
    }
}
