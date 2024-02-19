using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.DTOs.AccountRoles;
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
        public IEnumerable<AccountRoleDto> DetailAccRoleDto()
        {
            try
            {
                var custList = _context.Set<Customer>().ToList();
                var accList = _context.Set<Account>().ToList();
                var accRoleList = _context.Set<AccountRole>().ToList();
                var roleList = _context.Set<Role>().ToList();
                var detailRole = from accRole in accRoleList
                                 join cust in custList on accRole.AccountGuid equals cust.Guid
                                 join role in roleList on accRole.RoleGuid equals role.Guid
                                 select new AccountRoleDto
                                 {
                                     Guid = accRole.Guid,
                                     AccountGuid = accRole.AccountGuid,
                                     RoleGuid = role.Guid,
                                     Email = cust.Email,
                                     Role = role.RoleName
                                 };

                return detailRole;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
