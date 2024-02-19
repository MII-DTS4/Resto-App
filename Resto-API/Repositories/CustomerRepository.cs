using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class CustomerRepository : GeneralRepository<Customer>, ICustomerRepository
    {
        private readonly RestoAppDbContext _contextRole;
        public CustomerRepository(RestoAppDbContext context) : base(context)
        {
            _contextRole = context;
        }
        public Customer? GetByEmail(string email)
        {
            return _context.Set<Customer>().SingleOrDefault(c => c.Email.Contains(email));
        }
    }
}
