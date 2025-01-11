using Microsoft.AspNetCore.Mvc;

namespace OrderPathBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] OrderItems = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/order")]
        public IEnumerable<Order> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Order
            {
                Date = DateTime.Now.AddDays(index),
                PlacedBy = OrderItems[index],
                Item = OrderItems[index]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("/order")]
        public IActionResult PlaceOrder(Order order)
        {
            // raise event for order placement
            return Ok(order);

        }
    }
}
