using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Dtos;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await _context.Products.Select(x => GetProductDto(x)).ToListAsync();

            return Ok(list);
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();  
            }

            
            return Ok(GetProductDto(product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int? id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            
            var productQuery = await _context.Products.FindAsync(id);
            productQuery.Name = product.Name;
            productQuery.Price = product.Price;
            productQuery.Status = product.Status;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static ProductDto GetProductDto(Product product)
        {
            var entity = new ProductDto();
            if (product != null)
            {
                entity.Id = product.Id;
                entity.Name = product.Name;
                entity.Price = product.Price;
            }
            
            return entity;
        }
    }
}
