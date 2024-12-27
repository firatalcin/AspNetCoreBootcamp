using InventoryService.Data.Entities;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using static InvertoryService.API.Dtos.ItemDto;

namespace InvertoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository itemRepository;

        public ItemsController(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.itemRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await this.itemRepository.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateDto dto)
        {
            var result = await this.itemRepository.Create(new Item
            {
                Name = dto.Name,
            });
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemUpdateDto dto)
        {

            await this.itemRepository.Update(new Item
            {
                Id = dto.Id,
                Name = dto.Name,
            });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await this.itemRepository.Remove(id);
            return NoContent();
        }
    }
}
