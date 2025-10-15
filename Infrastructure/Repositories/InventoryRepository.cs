using Microsoft.EntityFrameworkCore;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Core.Entities;
using OptiTech.Infrastructure.Data;

namespace OptiTech.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;
        public InventoryRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(InventoryItem item)
        {
            _context.InventoryItems.Add(item);

            await _context.SaveChangesAsync();
        }

        public async Task<InventoryItem?> GetByProductIdAsync(int productId)
        {
            return await _context.InventoryItems
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Product.Id == productId);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
