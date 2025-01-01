using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Context;
using WebUI.Data;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = await _appDbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _appDbContext
                                .Students
                                //.Include(o => o.KursKayitlari)
                                //.ThenInclude(o => o.Kurs)
                                .FirstOrDefaultAsync(o => o.Id == id);

            if (ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Update(model);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_appDbContext.Students.Any(o => o.Id == model.Id))
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

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenci = await _appDbContext.Students.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var ogrenci = await _appDbContext.Students.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _appDbContext.Students.Remove(ogrenci);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
