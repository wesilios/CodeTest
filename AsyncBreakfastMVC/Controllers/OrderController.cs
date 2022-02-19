using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsyncBreakfastMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var orderId = await _orderService.CreateOrder();

            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            ViewData["orders"] = orders;

            return View();
        }
    }
}