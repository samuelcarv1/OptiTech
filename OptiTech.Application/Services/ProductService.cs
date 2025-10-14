using OptiTech.Application.DTOs;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Application.Interfaces.Services;
using OptiTech.Application.Mappings;
using OptiTech.Core.Entities;
using OptiTech.Core.Interfaces;
using OptiTech.Core.ValueObjects;

namespace OptiTech.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper<Product, ProductDto> _mapper;

        public ProductService(IProductRepository productRepository, IMapper<Product, ProductDto> mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateProductAsync(string name, decimal price)
        {
            var product = new Product(name, new Money(price));
            await _repository.AddAsync(product);

            return _mapper.Map(product);
        }

        public async Task<ProductDto> GetByIdAsync(int idProduct)
        {
            var product = await _repository.GetByIdAsync(idProduct);
            if (product == null) throw new Exception("Product not found");

            return _mapper.Map(product);
        }
    }
}
