using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITutorial.Contexts;

namespace WebAPITutorial.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id) 
        {
            var data = _context.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);
            
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);    
            }
        }
    }
}
