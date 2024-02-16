using Resto_API.Utilities.Handlers;
using Resto_API.Utilities.Handlers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.DTOs.Menu;
using Resto_API.Models;

namespace Resto_API.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _menuRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (ItemsDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<ItemsDto>>(data));
        }

        [HttpPost]
        public IActionResult Create(CreateMenuDto createMenuDto)
        {
            try
            {

                Item toCreate = createMenuDto;
                var result = _menuRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Update(ItemsDto itemsDto)
        {
            try
            {
                var entity = _menuRepository.GetByGuid(itemsDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = ItemsDto.ConvertToItem(itemsDto, entity);

                var result = _menuRepository.Update(entity);
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
                var leave = _menuRepository.GetByGuid(guid);
                if (leave is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _menuRepository.Delete(leave);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }

    }
}
