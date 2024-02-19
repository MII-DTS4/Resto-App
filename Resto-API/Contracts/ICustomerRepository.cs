using Resto_API.Models;

namespace Resto_API.Contracts
{
    public interface ICustomerRepository : IGeneralRepository<Customer>
    {
        Customer? GetByEmail(string email);
    }
}
