
using API.DTO.Accounts;
using API.DTOs.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.DTO.Accounts;
using Resto_API.DTOs.Menu;
using Resto_API.DTOs.Roles;
using Resto_API.Models;
using Resto_API.Repositories;
using Resto_API.Utilities.Handlers;
using Resto_API.Utilities.Handlers.Exceptions;
namespace Resto_API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RestoAppDbContext _dbContext;
        public AccountController(IRoleRepository roleRepository, RestoAppDbContext dbContext)
        {
            _roleRepository = roleRepository;
            _dbContext = dbContext;
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
        [HttpPost]
        public IActionResult Create(RoleDto createRoleDto)
        {
            try
            {

                Role toCreate = createRoleDto;
                var result = _roleRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Update(RoleDto roleDto)
        {
            try
            {
                var entity = _roleRepository.GetByGuid(roleDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                Role toUpdate = roleDto;
                var result = _roleRepository.Update(toUpdate);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }


        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var leave = _roleRepository.GetByGuid(guid);
                if (leave is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _roleRepository.Delete(leave);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
