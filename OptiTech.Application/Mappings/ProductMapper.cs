using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Application.DTOs;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Mappings
{
    public class ProductMapper : IMapper<Product, ProductDto>
    {
        public ProductDto Map(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price.Amount
            };
        }
    }
}
