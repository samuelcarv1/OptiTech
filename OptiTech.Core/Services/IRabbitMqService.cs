using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiTech.Core.Services
{
    public interface IRabbitMqService : IDisposable
    {
        void Publish<T>(string queueName, T message);
        void Consume(string queueName, Func<string, ulong, bool> handleMessage);
    }
}
