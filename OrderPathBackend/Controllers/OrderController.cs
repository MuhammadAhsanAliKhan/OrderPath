using Microsoft.AspNetCore.Mvc;
using OrderPathBackend.MessageBroker;

namespace OrderPathBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IPublisher _publish;

        public OrderController(ILogger<OrderController> logger, IPublisher publish)
        {
            _logger = logger;
            _publish = publish;
        }

        [HttpPost]
        [Route("/order")]
        public IActionResult PlaceOrder(Order order)
        {
            // raise event for order placement
            _publish.SendMessage($"Order placed by {order.PlacedBy} for {order.Item}");
            return Ok(order);

        }
    }
}
