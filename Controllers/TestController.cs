using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using WeatherApi.DatabaseContext;
using Xunit;

namespace WeatherApi.Controllers
{
    public class TestController : Controller
    {
        [Fact]
        public void TestGetWeather()
        {
            // Mock or instantiate dependencies
            var dbContextMock = new Mock<AppDbContext>();
            var memoryCacheMock = new Mock<IMemoryCache>();
            var httpClient = new HttpClient(); // Can mock if needed
            var configurationMock = new Mock<IConfiguration>();

            // Instantiate controller
            var controller = new WeatherController(dbContextMock.Object, memoryCacheMock.Object, httpClient, configurationMock.Object);

            // Call the action
            var result = controller.GetWeather("meka16110");

            // Assert the result (for example, check if OkResult is returned)
            Assert.IsType<OkResult>(result);
        }

    }
}
