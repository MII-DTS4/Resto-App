
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resto_API.Contracts;
using Resto_API.Data;
using Resto_API.DTO.Accounts;
using Resto_API.DTOs.Accounts;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICustomerRepository _customerRepository;

        private readonly RestoAppDbContext _dbContext;
        public AccountController(IAccountRepository accRepository, 
            IAccountRoleRepository accRoleRepository,
            ICustomerRepository custRepository,
            IRoleRepository roleRepository,
            RestoAppDbContext dbContext)
        {
            _accountRepository = accRepository;
            _accountRoleRepository = accRoleRepository;
            _roleRepository = roleRepository;
            _customerRepository = custRepository;
            _dbContext = dbContext;
        }
        
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountRepository.GetAll();
            if (!result.Any())
            {
                //return BadRequest("Data not Found");
                return NotFound();
            }
            var data = result.Select(item => (AccountDto)item);
            return Ok(new ResponseOkHandler<IEnumerable<AccountDto>>(data));
        }
        [HttpPost("register-customer")]
        [AllowAnonymous]
        public IActionResult RegisterCust(RegisterAccountDto registerCustDto)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                Account toCreate = registerCustDto;
                toCreate.Password = HashHandler.HashPassword(registerCustDto.Password);
                var result = _accountRepository.Create(toCreate);

                Customer toCustomer = registerCustDto;
                toCustomer.Guid = toCreate.Guid;
                var resultCust = _customerRepository.Create(toCustomer);

                Guid RoleGuid = _roleRepository.getDefaultRoleCust() ?? throw new Exception("Default role not found");
                var resultAccRole = _accountRoleRepository.CreateAccRole(toCustomer.Guid, RoleGuid);

                // Commit transaksi jika semuanya berhasil
                transaction.Commit();
                //return Ok(new ResponseOkHandler<String>($"{toCustomer.Guid},{toCreate.Guid},role : {RoleGuid}"));                
                return Ok(new ResponseOkHandler<String>("Data has been created successfully"));
            }
            catch (ExceptionHandler ex)
            {
                // Rollback transaksi jika terjadi kesalahan
                transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseInternalServerErrorHandler("Failed to create data", ex.Message));
            }
        }

        [HttpPut]
        public IActionResult Update(AccountDto accDto)
        {
            try
            {
                var entity = _accountRepository.GetByGuid(accDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                Account toUpdate = accDto;
                var result = _accountRepository.Update(toUpdate);
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
                var leave = _accountRepository.GetByGuid(guid);
                if (leave is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _accountRepository.Delete(leave);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
