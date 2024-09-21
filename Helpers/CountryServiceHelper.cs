using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WeatherApi.Models;

namespace WeatherApi.Helpers
{
    public class CountryServiceHelper
    {
        private readonly HttpClient _httpClient;

        public CountryServiceHelper( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateCountry(string countryCode)
        {
            // Prepare the API endpoint
            var url = $"https://restcountries.com/v3.1/alpha/{countryCode}";
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var countryData = JsonSerializer.Deserialize<List<Country>>(jsonResponse);

                    return countryData != null && countryData.Count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating country: {ex.Message}");
                return false;
            }
        }
    }
}
