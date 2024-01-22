﻿using Application.UseCases;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderUseCase _orderUseCase;
        public OrderController(IOrderUseCase orderUseCase, ILogger<OrderController> logger)
        {
            _orderUseCase = orderUseCase;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_orderUseCase.GetAllOrder());
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderViewModel order)
        {
            if(order == null)  return BadRequest("Invalid order data");

            try
            {
                var result = _orderUseCase.Post(order);

                if(result == null) return BadRequest("Error to create Order");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("NextStep")]
        public IActionResult NextStep([FromQuery] Guid orderId) 
        {
            if (orderId == Guid.Empty) return BadRequest("Invalid order data");

            try
            {
                if (_orderUseCase.NextStep(orderId)) return Ok("Order status updated");

                return BadRequest("Erro update Order status");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating product: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
