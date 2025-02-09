

using System.Text;
using System.Threading.Channels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OrderPathBackend.MessageBroker
{
    public class RabbitMQConsumer: IConsumer
    {
        private readonly IChannel channel;
        public RabbitMQConsumer()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            channel = connection.CreateChannelAsync().GetAwaiter().GetResult();

            channel.ExchangeDeclareAsync(exchange: "logs",
                type: ExchangeType.Fanout).GetAwaiter().GetResult();
        }
        public async Task ReceiveMessage(Func<string, Task> method)
        {
            QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync();
            string queueName = queueDeclareResult.QueueName;
            await channel.QueueBindAsync(queue: queueName, exchange: "logs", routingKey: string.Empty);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                method(message);
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
        }
    }
}
