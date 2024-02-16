using API.Utilities.Handlers;
using API.Utilities.Handlers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;

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
            var data = result.Select(i => (LeaveDetailStaffDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDetailStaffDto>>(data));
        }
    }
}
