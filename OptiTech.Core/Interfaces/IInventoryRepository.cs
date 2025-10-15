using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Repositories
{
    public interface IInventoryRepository
    {
        Task<InventoryItem?> GetByProductIdAsync(int productId);
        Task SaveChangesAsync();

        Task AddAsync(InventoryItem item);
    }
}
