using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Core.Entities;
using OptiTech.Core.Interfaces;
using OptiTech.Infrastructure.Data;

namespace OptiTech.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }
    }
}
