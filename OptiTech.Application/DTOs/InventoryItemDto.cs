using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiTech.Application.DTOs
{
    public class InventoryItemDto
    {
        public int idProduct { get; set; }
        public string NameProduct { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
