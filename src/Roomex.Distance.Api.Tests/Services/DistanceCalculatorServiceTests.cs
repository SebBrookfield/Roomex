using Moq;
using Roomex.Distance.Api.Enums;
using Roomex.Distance.Api.Services;
using Roomex.Distance.Api.Tests.MockBuilders;
using Xunit;

namespace Roomex.Distance.Api.Tests.Services;

public class DistanceCalculatorServiceTests
{
    [Fact]
    public void CalculateDistanceGetsTheCorrectCalculatorFromTheFactory()
    {
        var distanceCalculatorFactory = new MockDistanceCalculatorFactoryBuilder().Build(out var mockDistanceCalculatorFactory);
        var lengthConverterFactory = new MockLengthConverterFactoryBuilder().Build();
        var distanceCalculatorService = new DistanceCalculatorService(distanceCalculatorFactory, lengthConverterFactory);
        const DistanceCalculators distanceCalculator = DistanceCalculators.SphericalLawOfCosine;
        
        distanceCalculatorService.CalculateDistance(CoordinatesFor.Dublin, CoordinatesFor.France, distanceCalculator);

        mockDistanceCalculatorFactory.Verify(f => f.GetDistanceCalculator(distanceCalculator));
    }

    [Fact]
    public void CalculateDistanceGetsTheCorrectLengthConverterFromTheFactory()
    {
        var distanceCalculatorFactory = new MockDistanceCalculatorFactoryBuilder().Build();
        var lengthConverterFactory = new MockLengthConverterFactoryBuilder().Build(out var mockLengthConverterFactory);
        var distanceCalculatorService = new DistanceCalculatorService(distanceCalculatorFactory, lengthConverterFactory);
        var length = Lengths.Parsecs;
        
        distanceCalculatorService.CalculateDistance(CoordinatesFor.Dublin, CoordinatesFor.France, DistanceCalculators.SphericalLawOfCosine, length);

        mockLengthConverterFactory.Verify(f => f.GetMetreConverter(length));
    }

    [Fact]
    public void CalculateDistanceDoesNotGetAConverterFromTheFactoryIfLengthNotProvided()
    {
        var distanceCalculatorFactory = new MockDistanceCalculatorFactoryBuilder().Build();
        var lengthConverterFactory = new MockLengthConverterFactoryBuilder().Build(out var mockLengthConverterFactory);
        var distanceCalculatorService = new DistanceCalculatorService(distanceCalculatorFactory, lengthConverterFactory);

        distanceCalculatorService.CalculateDistance(CoordinatesFor.Dublin, CoordinatesFor.France, DistanceCalculators.SphericalLawOfCosine);

        mockLengthConverterFactory.Verify(f => f.GetMetreConverter(It.IsAny<Lengths>()), Times.Never);
    }

    [Fact]
    public void CalculateDistancePassesTheCorrectArgumentsToTheCalculator()
    {
        var coordinateA = CoordinatesFor.Dublin;
        var coordinateB = CoordinatesFor.France;
        var calculator = new MockDistanceCalculatorBuilder().Build(out var mockCalculator);
        var lengthConverter = new MockLengthConverterBuilder().Build();
        var distanceCalculatorFactory = new MockDistanceCalculatorFactoryBuilder()
            .WithCalculator(calculator)
            .Build();
        var lengthConverterFactory = new MockLengthConverterFactoryBuilder()
            .WithMetreConverter(lengthConverter)
            .Build();
        var distanceCalculatorService = new DistanceCalculatorService(distanceCalculatorFactory, lengthConverterFactory);

        distanceCalculatorService.CalculateDistance(coordinateA, coordinateB, DistanceCalculators.SphericalLawOfCosine, Lengths.Parsecs);

        mockCalculator.Verify(c => c.CalculateDistance(coordinateA, coordinateB, lengthConverter));
    }

    [Fact]
    public void CalculateDistanceReturnsTheDistanceFromTheCalculator()
    {
        const double expectedDistance = 123d;
        var coordinateA = CoordinatesFor.Dublin;
        var coordinateB = CoordinatesFor.France;
        var calculator = new MockDistanceCalculatorBuilder()
            .WithDistance(expectedDistance)
            .Build();
        var distanceCalculatorFactory = new MockDistanceCalculatorFactoryBuilder()
            .WithCalculator(calculator)
            .Build();
        var lengthConverterFactory = new MockLengthConverterFactoryBuilder().Build();
        var distanceCalculatorService = new DistanceCalculatorService(distanceCalculatorFactory, lengthConverterFactory);

        var distance = distanceCalculatorService.CalculateDistance(coordinateA, coordinateB, DistanceCalculators.SphericalLawOfCosine);

        Assert.Equal(expectedDistance, distance);
    }
}