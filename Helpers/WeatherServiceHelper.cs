using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace WeatherApi.Helpers
{
    public class WeatherServiceHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
      
        public WeatherServiceHelper(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

        }
        public async Task<string> FetchWeatherFromApi(string country)
        {
            var weatherAPI = _configuration.GetSection("WeatherAPI");
            var weatherApiKey = weatherAPI["ApiKey"];
            var url = ($"https://api.openweathermap.org/data/2.5/weather?q={country}&appid={weatherApiKey}");
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return (jsonResponse);
                }

                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating country: {ex.Message}");
                return "";
            }
        }


    }
}
