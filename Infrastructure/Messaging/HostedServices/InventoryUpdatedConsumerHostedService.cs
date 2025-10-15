using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OptiTech.Core.Services;
using OptiTech.Infrastructure.Messaging.Consumers;
using OptiTech.Infrastructure.Messaging.Events;

namespace OptiTech.Infrastructure.Messaging.HostedServices
{
    public class InventoryUpdatedConsumerHostedService : BackgroundService
    {
        private readonly IRabbitMqService _rabbitMqService;
        private readonly InventoryUpdatedConsumer _consumer;
        private readonly ILogger<InventoryUpdatedConsumerHostedService> _logger;
        private const string QUEUE_NAME = "inventory.updated";


        public InventoryUpdatedConsumerHostedService(IRabbitMqService rabbitMqService, ILogger<InventoryUpdatedConsumerHostedService> logger, InventoryUpdatedConsumer consumer)
        {
            _rabbitMqService = rabbitMqService;
            _logger = logger;
            _consumer = consumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Consumer iniciado, escutando fila {queue}", QUEUE_NAME);

            // Passa a função HandleMessage do InventoryUpdatedConsumer
            _rabbitMqService.Consume(QUEUE_NAME, _consumer.HandleMessage);

            return Task.CompletedTask;
        }

    }
}
