using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Roomex.Distance.Api.Models;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Models;
using Xunit;

namespace Roomex.Distance.Api.IntegrationTests
{
    public class DistanceControllerTests
    {
        private readonly HttpClient _client;

        public DistanceControllerTests()
        {
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            _client = application.CreateClient();
        }

        [Fact]
        public async Task CalculateReturnsCorrectValue()
        {
            var request = new CalculateDistanceRequest
            {
                CoordinateA = new DecimalDegreeCoordinate(53.297975, -6.372663),
                CoordinateB = new DecimalDegreeCoordinate(41.385101, -81.440440)
            };

            var distance = await Calculate(request);

            Assert.Equal("5536.346304530242", distance);
        }

        [Fact]
        public async Task CalculateReturnsCorrectValueWhenUsingADifferentCalculationMethod()
        {
            var request = new CalculateDistanceRequest
            {
                CoordinateA = new DecimalDegreeCoordinate(53.297975, -6.372663),
                CoordinateB = new DecimalDegreeCoordinate(41.385101, -81.440440),
                CalculationMethod = DistanceCalculators.VincentyInverse
            };

            var distance = await Calculate(request);

            Assert.Equal("5551.627484580547", distance);
        }

        [Fact]
        public async Task CalculateReturnsCorrectValueWhenUsingADifferentOutputLength()
        {
            var request = new CalculateDistanceRequest
            {
                CoordinateA = new DecimalDegreeCoordinate(53.297975, -6.372663),
                CoordinateB = new DecimalDegreeCoordinate(41.385101, -81.440440),
                UnitOutput = Lengths.Miles
            };

            var distance = await Calculate(request);

            Assert.Equal("3440.126146861522", distance);
        }

        private async Task<string> Calculate(CalculateDistanceRequest request)
        {
            var response = await _client.PostAsync("Distance/Calculate", new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}