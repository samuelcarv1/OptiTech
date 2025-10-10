using OptiTech.Core.Aggregates;

namespace OptiTech.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int customerId);
        Task AddItemToOrderAsync(int orderId, int productId, int quantity);
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
