using OptiTech.Application.DTOs;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(string name, decimal price);
        Task<ProductDto> GetByIdAsync(int idProduct);
    }
}
