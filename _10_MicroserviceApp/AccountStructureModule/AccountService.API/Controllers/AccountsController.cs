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
        public IActionResult Get()
        {
            var repository = new PlayerRepository();
            return Ok();
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
    }
}
