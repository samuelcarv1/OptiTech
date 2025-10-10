using Microsoft.AspNetCore.Mvc;
using OptiTech.Application.DTOs;
using OptiTech.Application.Interfaces.Services;

namespace OptiTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var order = await _orderService.CreateOrderAsync(dto.CustomerId);
            return Ok(order);
        }

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItem(int orderId, [FromBody] AddItemDto dto)
        {
            await _orderService.AddItemToOrderAsync(orderId, dto.ProductId, dto.Quantity);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order); // pode mapear para DTO
        }
    }
}
