using Microsoft.AspNetCore.Mvc;
using OptiTech.Application.Interfaces.Services;

namespace OptiTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost("add-stock")]
        public async Task<IActionResult> AddStock(int idProduct, int quantity)
        {
            var item = await _inventoryService.AddStockAsync(idProduct, quantity);
            return Ok(item);
        }

        [HttpGet("{idProduct}")]
        public async Task<IActionResult> GetByProductId(int idProduct)
        {
            var item = await _inventoryService.GetbyIdProductAsync(idProduct);
            return Ok(item);
        }
    }
}
