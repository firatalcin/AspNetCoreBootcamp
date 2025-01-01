using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPITutorial.Data;
using WebAPITutorial.Interfaces;

namespace WebAPITutorial.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Ok(200), NotFound(404), NoContent(204), Created(201), BadRequest(400)
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Member")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);

            return Created(string.Empty, addedProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkProduct = await _productRepository.GetByIdAsync(product.Id);
            if(checkProduct == null)
            {
                return NotFound();
            }
            else
            {
                await _productRepository.UpdateAsync(product);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkProduct = await _productRepository.GetByIdAsync(id);
            if (checkProduct == null)
            {
                return NotFound();
            }
            else
            {
                await _productRepository.RemoveAsync(id);
                return NoContent();
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }

        [HttpGet("[action]")]
        //[FromForm] string name, [FromHeader] string auth, test
        public IActionResult Test([FromServices] IDummyRepository dummyRepository)
        {
            // request => response 
            // header, body 

            //var authentication = HttpContext.Request.Headers["auth"];

            //var name2 = HttpContext.Request.Form["name"];
            return Ok(dummyRepository.GetName());
        }

    }
}
