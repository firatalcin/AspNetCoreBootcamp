using Microsoft.AspNetCore.Mvc;
using Basics.Models;

namespace Basics.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            Course kurs = new Course();
            kurs.Id = 1;
            kurs.Title = "Aspnet Core kursu";
            return View(kurs);
        }

        public IActionResult List(){         
            return View(Repository.Courses);
        }

        public IActionResult Details(int id){
            var kurs = Repository.GetById(id);

            return View(kurs);
        }

    }
}