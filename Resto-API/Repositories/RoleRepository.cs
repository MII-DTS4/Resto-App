using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.Models;

namespace Resto_API.Repositories
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        private readonly RestoAppDbContext _contextRole;
        public RoleRepository(RestoAppDbContext context) : base(context)
        {
            _contextRole = context;
        }
    }
}
