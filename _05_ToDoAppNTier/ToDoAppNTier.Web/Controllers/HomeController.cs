using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;
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

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto request)
        {
            if(ModelState.IsValid)
            {
                await _workService.Create(request);
                return RedirectToAction("Index");
            }

            return View(request);
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetById(id);
            return View(new WorkUpdateDto
            {
                Id = dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto request)
        {
            if (ModelState.IsValid) 
            {
                await _workService.Update(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
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
