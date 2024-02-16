using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        private readonly RestoAppDbContext _contextRole;
        public AccountRepository(RestoAppDbContext context) : base(context)
        {
            _contextRole = context;
        }
    }
}
