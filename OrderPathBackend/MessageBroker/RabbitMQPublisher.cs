﻿using System.Text;
using System.Threading.Channels;
using RabbitMQ;
using RabbitMQ.Client;

namespace OrderPathBackend.MessageBroker
{
    public class RabbitMQPublisher : IPublisher
    {
        private readonly IChannel channel;


        public RabbitMQPublisher() 
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            channel = connection.CreateChannelAsync().GetAwaiter().GetResult();

            channel.ExchangeDeclareAsync(exchange: "logs", type: ExchangeType.Fanout).GetAwaiter().GetResult();
        }


        public async void SendMessage(string message)
        {

            var body = Encoding.UTF8.GetBytes(message);
            

            await channel.BasicPublishAsync(exchange: "logs", routingKey: string.Empty, body: body);
        }


    }
}
