using Microsoft.AspNetCore.Mvc;
using WeatherApi.DatabaseContext;
using WeatherApi.Helpers;
using WeatherApi.RequestDTO;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController(AppDbContext context, IConfiguration configuration) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IConfiguration _configuration = configuration;

        public IActionResult SignIn([FromBody] LoginRequestDTO loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.FirstOrDefault(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
                return Unauthorized();

            // Generate JWT token
            JwtTokenHelper jwtTokenHelper = new JwtTokenHelper(_configuration);
            var token = jwtTokenHelper.GenerateJwtToken(user);

            return Ok( token );
        }  
    }
}