using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.UI.Models;

namespace ToDoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workService.Create(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workService.Update(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
