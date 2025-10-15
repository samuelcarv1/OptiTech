using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Application.DTOs;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Interfaces.Services
{
    public interface IInventoryService
    {
        Task<InventoryItemDto> AddStockAsync(int idProduct, int quantity);
        Task<InventoryItemDto> GetbyIdProductAsync(int idProduct);
    }
}
