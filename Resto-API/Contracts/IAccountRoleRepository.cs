using Resto_API.DTOs.AccountRoles;
using Resto_API.Models;

namespace Resto_API.Contracts
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
    {
        AccountRole? CreateAccRole(Guid entity, Guid role);
        IEnumerable<AccountRoleDto> DetailAccRoleDto();
    }
}
