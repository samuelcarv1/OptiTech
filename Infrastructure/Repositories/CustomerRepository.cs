using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Core.Entities;
using OptiTech.Infrastructure.Data;

namespace OptiTech.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }
    }
}
