using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AsyncBreakfastMVC.Models;
using AsyncBreakfastMVC.Tasks;

namespace AsyncBreakfastMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBreakfast _breakfast;

        public HomeController(ILogger<HomeController> logger, IBreakfast breakfast)
        {
            _logger = logger;
            _breakfast = breakfast;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            // take 15s
            var actions = _breakfast.MakeBreakFast();
            // take 15s
            var actionsAsync = await _breakfast.MakeBreakFastAsync();
            // total 35
            return View();
        }

        public async Task<IActionResult> MakeBreakfast()
        {
            // take 15 for task one and task two
            var taskOne = Task.Run(() => _breakfast.MakeBreakFast());
            var taskTwo = Task.Run(() => _breakfast.MakeBreakFastAsync());
            ViewData["actions"] = await taskOne;
            ViewData["actionWithAsync"] = await taskTwo;

            return View();
        }

        public async Task<IActionResult> AsyncMakeBreakfast()
        {
            var taskOne = Task.Run(() => _breakfast.MakeBreakFastAsync());
            var taskTwo = Task.Run(() => _breakfast.MakeBreakFastMultiThreadAsync());
            ViewData["actions"] = await taskOne;
            ViewData["actionWithAsync"] = await taskTwo;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}