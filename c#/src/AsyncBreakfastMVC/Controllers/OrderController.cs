using System.Threading.Tasks;
using AsyncBreakfastMVC.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AsyncBreakfastMVC.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
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