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
        private readonly IBreakfastRecipe _breakfastRecipe;

        public HomeController(ILogger<HomeController> logger, IBreakfastRecipe breakfastRecipe)
        {
            _logger = logger;
            _breakfastRecipe = breakfastRecipe;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> MakeBreakfast()
        {
            var taskOne = Task.Run(() => _breakfastRecipe.MakeBreakfast());
            var taskTwo = Task.Run(() => _breakfastRecipe.MakeBreakfastAsync());
            var breakfastOne = await taskOne;
            var breakfastTwo= await taskTwo;
            ViewData["actions"] = breakfastOne.Actions;
            ViewData["actionWithAsync"] = breakfastTwo.Actions;

            return View();
        }

        public async Task<IActionResult> AsyncMakeBreakfast()
        {
            var taskOne = Task.Run(() => _breakfastRecipe.MakeBreakfastAsync());
            var taskTwo = Task.Run(() => _breakfastRecipe.MakeBreakfastMultiThreadAsync());
            var breakfastOne = await taskOne;
            var breakfastTwo= await taskTwo;
            ViewData["actions"] = breakfastOne.Actions;
            ViewData["actionWithAsync"] = breakfastTwo.Actions;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}