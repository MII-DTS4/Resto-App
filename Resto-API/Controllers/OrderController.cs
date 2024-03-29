﻿using Microsoft.AspNetCore.Mvc;
using Resto_API.Contracts;
using Resto_API.DTOs.Menu;
using Resto_API.Models;
using Resto_API.Utilities.Handlers.Exceptions;
using Resto_API.Utilities.Handlers;
using Resto_API.DTOs.Wishlist;
using Resto_API.DTOs.Transactions;
using Resto_API.Repositories;

namespace Resto_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITransactionRepository _transactionRepository;

        public OrderController(IOrderRepository orderRepository, ITransactionRepository transactionRepository)
        {
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<Order>>(result));
        }
        [HttpPost]
        public IActionResult Create(ICollection<CreateOrderDto> createOrderDtos)
        {
            try
            {
                var priceTransaction = 0;
                var invoice = "";

                foreach (Order order in createOrderDtos)
                {
                    priceTransaction += order.TotalPrice * order.TotalItem;
                    _orderRepository.Create(order);
                }
                Transaction createtransact = CreateTransactionDto.CreateTransaction(priceTransaction, invoice);
                createtransact.CustomerGuid = createOrderDtos.First().CustomerGuid;
                var result = _transactionRepository.Create(createtransact);

                

                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", ex.Message));
            }
        }

    }
}
