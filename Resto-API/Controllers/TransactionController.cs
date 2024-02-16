using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.DTOs.Menu;
using Resto_API.Repositories;
using Resto_API.Utilities.Handlers.Exceptions;
using Resto_API.Utilities.Handlers;
using Resto_API.DTOs.Transactions;

namespace Resto_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPut]
        public IActionResult Update(TransactionDto transactionDto)
        {
            try
            {
                var entity = _transactionRepository.GetByGuid(transactionDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = TransactionDto.ConvertToTransaction(entity, transactionDto);

                var result = _transactionRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
