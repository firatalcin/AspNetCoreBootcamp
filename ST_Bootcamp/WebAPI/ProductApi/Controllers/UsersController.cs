using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductApi.Dtos;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IConfiguration _configuration;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = new AppUser { UserName = userDto.UserName, Email = userDto.Email, FullName = userDto.FullName, CreateDate = DateTime.Now};
            
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return BadRequest(new {message = "Email or password is incorrect"});
            }
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJwt(user) });
            }

            return Unauthorized();
        }

        private object GenerateJwt(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Key").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName ?? ""),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
