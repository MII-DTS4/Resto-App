using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.DTOs.Roles;
using Resto_API.Utilities.Handlers;
using System.Net;

namespace Resto_API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleRepository.GetAll();
            if (!result.Any())
            {
                //return BadRequest("Data not Found");
                return NotFound();
            }
            var data = result.Select(item => (RoleDto)item);
            return Ok(new ResponseOkHandler<IEnumerable<RoleDto>>(data));
        }
    }
}
