using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
    }
}
