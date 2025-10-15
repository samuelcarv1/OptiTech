using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OptiTech.Core.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OptiTech.Infrastructure.Messaging
{
    public class RabbitMqService : IRabbitMqService, IDisposable
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Consume(string queueName, Func<string, ulong, bool> handleMessage)
        {
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                bool processed = handleMessage(message, ea.DeliveryTag);

                if (processed)
                    _channel.BasicAck(ea.DeliveryTag, false);
                else
                    _channel.BasicNack(ea.DeliveryTag, false, true);
            };

            _channel.BasicConsume(queueName, autoAck: false, consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }

        public void Publish<T>(string queueName, T message)
        {
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            _channel.BasicPublish("", queueName, null, body);
        }
    }
}
