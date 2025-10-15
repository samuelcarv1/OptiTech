using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Application.DTOs;
using OptiTech.Core.Entities;

namespace OptiTech.Application.Mappings
{
    public class InventoryMapper : IMapper<InventoryItem, InventoryItemDto>
    {
        public InventoryItemDto Map(InventoryItem inventory)
        {
            return new InventoryItemDto
            {
                idProduct = inventory.ProductId,
                NameProduct = inventory.Product.Name,
                Price = inventory.Product.Price.Amount,
                Quantity = inventory.Quantity
            };
        }
    }
}
