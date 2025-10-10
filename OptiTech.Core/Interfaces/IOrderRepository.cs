using OptiTech.Core.Aggregates;

namespace OptiTech.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int orderId);
        Task AddAsync(Order order);
        Task SaveChangesAsync();

    }
}
