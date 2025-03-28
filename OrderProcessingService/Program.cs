using MessageBroker;
using MessageBroker.RabbitMQ;

namespace OrderProcessingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddSingleton<IConsumer, RabbitMQConsumer>();

            var host = builder.Build();
            host.Run();
        }
    }
}