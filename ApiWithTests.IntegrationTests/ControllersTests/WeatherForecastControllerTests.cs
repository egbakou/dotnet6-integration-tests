using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiWithTests.IntegrationTests.ControllersTests
{
    public class WeatherForecastControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public WeatherForecastControllerTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_WeatherForecast_Should_Return_OK()
        {
            var response = await _client.GetAsync("/WeatherForecast");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Call_Swagger_Should_Return_OK()
        {
            var response = await _client.GetAsync("/swagger/index.html");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
