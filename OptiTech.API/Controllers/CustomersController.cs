using Microsoft.AspNetCore.Mvc;
using OptiTech.Application.DTOs;
using OptiTech.Application.Interfaces.Services;

namespace OptiTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            var customer = await _customerService.CreateCustomerAsync(dto.Name, dto.Email);
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
