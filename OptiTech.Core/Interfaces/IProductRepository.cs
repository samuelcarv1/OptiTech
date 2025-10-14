using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Core.Entities;

namespace OptiTech.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task AddAsync(Product product);
    }
}
