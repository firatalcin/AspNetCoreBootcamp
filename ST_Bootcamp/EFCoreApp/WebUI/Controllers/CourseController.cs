using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Context;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Courses = await _context.Courses.Include(k => k.Teacher).ToListAsync();
            return View(Courses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "Id", "NameSurname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(new Course() { Id = model.Id, Name = model.Name, TeacherId = model.TeacherId });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "OgretmenId", "AdSoyad");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context
                        .Courses
                        .Include(k => k.Registers)
                        .ThenInclude(k => k.Student)
                        .Select(k => new CourseViewModel
                        {
                            Id = k.Id,
                            Name = k.Name,
                            TeacherId = k.TeacherId,
                            Registers = k.Registers
                        })
                        .FirstOrDefaultAsync(k => k.Id == id);

            if (kurs == null)
            {
                return NotFound();
            }

            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "OgretmenId", "AdSoyad");

            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Course() { Id = model.Id, Name = model.Name, TeacherId = model.TeacherId });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!_context.Courses.Any(o => o.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "Id", "NameSurname");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Courses.FindAsync(id);

            if (kurs == null)
            {
                return NotFound();
            }

            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var kurs = await _context.Courses.FindAsync(id);
            if (kurs == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




    }
}
