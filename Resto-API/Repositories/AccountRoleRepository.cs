using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
    {
        private readonly RestoAppDbContext _contextRole;
        public AccountRoleRepository(RestoAppDbContext context) : base(context)
        {
            _contextRole = context;
        }
    }
}
