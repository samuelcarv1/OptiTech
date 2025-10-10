
using Microsoft.EntityFrameworkCore;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Core.Aggregates;
using OptiTech.Infrastructure.Data;

namespace OptiTech.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
