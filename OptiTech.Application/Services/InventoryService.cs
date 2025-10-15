using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptiTech.Application.DTOs;
using OptiTech.Application.Interfaces.Repositories;
using OptiTech.Application.Interfaces.Services;
using OptiTech.Application.Mappings;
using OptiTech.Core.Entities;
using OptiTech.Core.Interfaces;
using OptiTech.Core.Services;
using OptiTech.Infrastructure.Messaging.Events;

namespace OptiTech.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper<InventoryItem,InventoryItemDto> _mapper;
        private readonly IRabbitMqService _rabbitService;

        public InventoryService(IInventoryRepository inventoryRepositor, IProductRepository productRepository, IMapper<InventoryItem, InventoryItemDto> mapper, IRabbitMqService rabbitMqService)
        {
            _inventoryRepository = inventoryRepositor;
            _productRepository = productRepository;
            _mapper = mapper;
            _rabbitService = rabbitMqService;
        }

        public async Task<InventoryItemDto> AddStockAsync(int idProduct, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(idProduct) ?? throw new Exception("Produto não encontrado");

            var existingItem = await _inventoryRepository.GetByProductIdAsync(idProduct);
            if(existingItem != null)
            {
                existingItem.IncreaseStock(quantity);
            }
            else
            {
                existingItem = new InventoryItem(product, quantity);
                await _inventoryRepository.AddAsync(existingItem);
            }

            await _inventoryRepository.SaveChangesAsync();

            var eventMessage = new InventoryUpdatedEvent { idProduct = idProduct, Quantity = quantity };
            _rabbitService.Publish("inventory-updated", eventMessage);

            return _mapper.Map(existingItem);
        }

        public async Task<InventoryItemDto> GetbyIdProductAsync(int idProduct)
        {
            var item = await _inventoryRepository.GetByProductIdAsync(idProduct)
                ?? throw new Exception("Produto sem estoque cadastrado");

            return _mapper.Map(item);

        }
    }
}
