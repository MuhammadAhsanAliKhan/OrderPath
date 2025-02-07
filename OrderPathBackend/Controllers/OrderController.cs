using Microsoft.AspNetCore.Mvc;

namespace OrderPathBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
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
