using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(string name, string email);
        Task<Customer> GetByIdAsync(int id);
    }
}
