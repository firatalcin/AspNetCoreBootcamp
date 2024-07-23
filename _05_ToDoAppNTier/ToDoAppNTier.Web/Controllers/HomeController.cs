using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Web.Models;

namespace ToDoAppNTier.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService , ILogger<HomeController> logger)
        {
            _workService = workService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
