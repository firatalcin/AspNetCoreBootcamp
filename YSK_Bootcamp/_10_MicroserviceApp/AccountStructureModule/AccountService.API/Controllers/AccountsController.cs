using AccountService.API.Dtos;
using AccountService.Data.Entities;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;

        public AccountsController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok(await _playerRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto player)
        {
            await _playerRepository.Create(new Player
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Username = player.Username
            });

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _playerRepository.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _playerRepository.Remove(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlayerUpdateDto dto)
        {
            await _playerRepository.Update(new Data.Entities.Player { FirstName = dto.FirstName, LastName = dto.LastName, Username = dto.Username, Id = dto.Id });

            return NoContent();
        }
    }
}
