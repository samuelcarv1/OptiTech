using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OptiTech.Core.Services;
using OptiTech.Infrastructure.Messaging.Events;

namespace OptiTech.Infrastructure.Messaging.Consumers
{
    public  class InventoryUpdatedConsumer
    {
        private readonly ILogger<InventoryUpdatedConsumer> _logger;

        public InventoryUpdatedConsumer(ILogger<InventoryUpdatedConsumer> logger)
        {
            _logger = logger;
        }

        public bool HandleMessage(string message, ulong deliveryTag)
        {
            try
            {
                _logger.LogInformation(" Mensagem recebida: {message}", message);
                var evento = JsonSerializer.Deserialize<InventoryUpdatedEvent>(message);

                if (evento == null)
                {
                    _logger.LogWarning("Evento inválido ou nulo");
                    return false;
                }

                _logger.LogInformation("Estoque atualizado: Produto {idProduct}, Nova quantidade: {quantity}",
                    evento.idProduct, evento.Quantity);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar mensagem");
                return false;
            }
        }
    }
}
