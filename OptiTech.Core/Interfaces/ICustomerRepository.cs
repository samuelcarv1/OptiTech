using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int customerId);
        Task AddAsync(Customer customer);
    }
}
