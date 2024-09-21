using Microsoft.AspNetCore.Mvc;
using WeatherApi.DatabaseContext;
using WeatherApi.Models;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public RegistrationController(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CountryServiceHelper countryServiceHelper = new CountryServiceHelper(_httpClient);
            var countryValidation = await countryServiceHelper.ValidateCountry(user.LivingCountry);
            if (!countryValidation)
                return BadRequest("Invalid country");

            // Generate unique username
            user.Username = UserNameHelper.GenerateUsername(user.Firstname, user.Lastname);

            if (_context.Users.Any(m=>m.Username == user.Username)) // it can be customizable
                return Conflict(new { Message = "User already exists" });
            
           // user.Password = _passwordHasher.HashPassword(user, user.Password); if need we can hash the password
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered: ", username = user.Username });
        }
    }
}
