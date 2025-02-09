using OrderPathBackend.MessageBroker;

namespace OrderProcessingService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumer _consumer;

        public Worker(ILogger<Worker> logger, IConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _consumer.RecieveMessage(GetMessage);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task GetMessage(string message)
        {
            // insert in db
            Console.WriteLine($"from my delegate i print {message}");
        }
    }
}
