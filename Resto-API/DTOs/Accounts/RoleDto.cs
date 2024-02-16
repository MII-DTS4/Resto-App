using Resto_API.DTOs;
using Resto_API.Models;

namespace Resto_API.DTOs.Roles;

public class RoleDto : GeneralGuid
{
    public string RoleName { get; set; }

    public static explicit operator RoleDto(Role role) 
    {
        return new RoleDto
        {
            Guid = role.Guid,
            RoleName = role.RoleName
        };
    }

    public static implicit operator Role(RoleDto roleDto)
    {
        return new Role
        {
            Guid = roleDto.Guid,
            RoleName = roleDto.RoleName
        };
    }
}