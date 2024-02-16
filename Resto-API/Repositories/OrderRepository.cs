using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class OrderRepository : GeneralRepository<Order> , IOrderRepository
    {
        public OrderRepository(RestoAppDbContext context) : base(context)
        {
        }
    }
}
