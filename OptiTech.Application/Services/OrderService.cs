using Microsoft.EntityFrameworkCore;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Application.Interfaces.Services;
using OptiTech.Core.Aggregates;
using OptiTech.Infrastructure.Data;

namespace OptiTech.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IProductRepository _productRepo;
        private readonly IInventoryRepository _inventoryRepo;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository, IInventoryRepository inventoryRepository)
        {
            _orderRepo = orderRepository;
            _customerRepo = customerRepository;
            _productRepo = productRepository;
            _inventoryRepo = inventoryRepository;
        }

        public async Task<Order> CreateOrderAsync(int customerId)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId);
            if (customer == null) throw new Exception("Customer not found");

            var order = new Order(customer);
            await _orderRepo.AddAsync(order);
            return order;
        }

        public async Task AddItemToOrderAsync(int orderId, int productId, int quantity)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null) throw new Exception("Order not found");

            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null) throw new Exception("Product not found");

            var inventoryItem = await _inventoryRepo.GetByProductIdAsync(productId);
            if (inventoryItem == null || inventoryItem.Quantity < quantity)
                throw new Exception("Not enough stock");

            inventoryItem.DecreaseStock(quantity);
            order.AddItem(product, quantity);

            await _inventoryRepo.SaveChangesAsync();
            await _orderRepo.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order == null) throw new Exception("Order not found");
            return order;
        }
    }
}
