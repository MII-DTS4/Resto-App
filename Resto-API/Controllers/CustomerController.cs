using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.Models;
using System.Net;

namespace Resto_API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerRepository.GetAll();
            if (!result.Any())
            {
                //return BadRequest("Data not Found");
                return NotFound();
            }
            
            return Ok(result);
        }
    }
}
