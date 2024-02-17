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
        public AccountRole? CreateAccRole(Guid entity,Guid role)
        {
            try
            {
                var newAccRole = new AccountRole
                {
                    AccountGuid = entity,
                    RoleGuid = role
                };
                _contextRole.Set<AccountRole>().Add(newAccRole);
                _contextRole.SaveChanges();
                return newAccRole;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
