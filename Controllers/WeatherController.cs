using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using WeatherApi.DatabaseContext;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherController(AppDbContext context, IMemoryCache cache, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _cache = cache;
            _httpClient = httpClient;
            _configuration = configuration;
        }
        [HttpGet("{username}")]
        public async Task<IActionResult> GetWeather(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return NotFound("User not found");

            var cacheKey = $"weather_{user.LivingCountry}";
            if (!_cache.TryGetValue(cacheKey, out string weatherData))
            {
                WeatherServiceHelper weatherServiceHelper = new WeatherServiceHelper(_httpClient,_configuration);
                weatherData = await weatherServiceHelper.FetchWeatherFromApi(user.LivingCountry);
                _cache.Set(cacheKey, weatherData, TimeSpan.FromHours(1));
            }
            var parsedWeather = JsonConvert.DeserializeObject(weatherData);
            // Print out the parsed JSON
            var formattedJson = JsonConvert.SerializeObject(parsedWeather, Formatting.Indented);
            return Ok(formattedJson);
        }

    }

}
