using Resto_API.Utilities.Handlers;
using Resto_API.Utilities.Handlers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.DTOs.Menu;
using Resto_API.Models;
using Resto_API.DTOs.AccountRoles;

namespace Resto_API.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]")]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleRepository _accRoleRepository;

        public AccountRoleController(IAccountRoleRepository accRoleRepo)
        {
            _accRoleRepository = accRoleRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accRoleRepository.DetailAccRoleDto();
            //var result = _accRoleRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }

            //return Ok(new ResponseOkHandler<IEnumerable<AccountRoleDto>>(result));
            return Ok(new ResponseOkHandler<IEnumerable<AccountRoleDto>>(result));
        }

        //[HttpPost]
        //public IActionResult Create(CreateMenuDto createMenuDto)
        //{
        //    try
        //    {

        //        Item toCreate = createMenuDto;
        //        var result = _accRoleRepository.Create(toCreate);
        //        return Ok(new ResponseOkHandler<string>("Data Created Successfully"));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", ex.Message));
        //    }
        //}

        //[HttpPut]
        //public IActionResult Update(ItemsDto itemsDto)
        //{
        //    try
        //    {
        //        var entity = _accRoleRepository.GetByGuid(itemsDto.Guid);
        //        if (entity is null)
        //        {
        //            return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //        }
        //        entity = ItemsDto.ConvertToItem(itemsDto, entity);

        //        var result = _accRoleRepository.Update(entity);
        //        return Ok(new ResponseOkHandler<String>("Data Updated"));

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }

        //}


        //[HttpDelete("{guid}")]
        //public IActionResult Delete(Guid guid)
        //{
        //    try
        //    {
        //        var leave = _menuRepository.GetByGuid(guid);
        //        if (leave is null)
        //        {
        //            return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //        }
        //        var result = _menuRepository.Delete(leave);
        //        return Ok(new ResponseOkHandler<String>("Data Deleted"));

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }

        //}

    }
}
