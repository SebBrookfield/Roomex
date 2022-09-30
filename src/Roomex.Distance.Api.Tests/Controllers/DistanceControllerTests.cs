using Moq;
using Roomex.Distance.Api.Controllers;
using Roomex.Distance.Api.Models;
using Roomex.Distance.Api.Tests.MockBuilders;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Models;
using Xunit;

namespace Roomex.Distance.Api.Tests.Controllers;

public class DistanceControllerTests
{
    [Fact]
    public void DistanceControllerDoesNotThrow()
    {
        var distanceCalculatorSerivce = new MockDistanceCalculatorService().Build();
        Assert.Null(Record.Exception(() => new DistanceController(distanceCalculatorSerivce)));
    }

    [Fact]
    public void CalculateReturnsDistance()
    {
        const double expectedDistance = 123d;
        var distanceCalculatorService = new MockDistanceCalculatorService().WithDistance(expectedDistance).Build();
        var controller = new DistanceController(distanceCalculatorService);

        var distance = controller.Calculate(new CalculateDistanceRequest());

        Assert.Equal(expectedDistance, distance);
    }

    [Fact]
    public void CalculateDefaultsToSphericalLawOfCosineIfNoCalculationMethodSpecified()
    {
        var distanceCalculatorService = new MockDistanceCalculatorService().Build(out var mock);
        var controller = new DistanceController(distanceCalculatorService);

        controller.Calculate(new CalculateDistanceRequest());

        mock.Verify(s => s.CalculateDistance(It.IsAny<DecimalDegreeCoordinate>(), It.IsAny<DecimalDegreeCoordinate>(), DistanceCalculators.SphericalLawOfCosine, It.IsAny<Lengths?>()));
    }

    [Fact]
    public void CalculateDefaultsToKilometresIfNoLengthSpecified()
    {
        var distanceCalculatorService = new MockDistanceCalculatorService().Build(out var mock);
        var controller = new DistanceController(distanceCalculatorService);

        controller.Calculate(new CalculateDistanceRequest());

        mock.Verify(s => s.CalculateDistance(It.IsAny<DecimalDegreeCoordinate>(), It.IsAny<DecimalDegreeCoordinate>(), It.IsAny<DistanceCalculators>(), Lengths.Kilometres));
    }

    [Fact]
    public void CalculateForwardsTheCorrectCalculationMethodAndLengthIfSpecified()
    {
        var distanceCalculatorService = new MockDistanceCalculatorService().Build(out var mock);
        var controller = new DistanceController(distanceCalculatorService);
        var request = new CalculateDistanceRequest
        {
            CalculationMethod = DistanceCalculators.VincentyInverse,
            UnitOutput = Lengths.Miles
        };
        
        controller.Calculate(request);

        mock.Verify(s => s.CalculateDistance(It.IsAny<DecimalDegreeCoordinate>(), It.IsAny<DecimalDegreeCoordinate>(), request.CalculationMethod.Value, request.UnitOutput.Value));
    }

    [Fact]
    public void CalculateForwardsTheCorrectCoordinates()
    {
        var distanceCalculatorService = new MockDistanceCalculatorService().Build(out var mock);
        var controller = new DistanceController(distanceCalculatorService);
        var request = new CalculateDistanceRequest
        {
            CoordinateA = new DecimalDegreeCoordinate(1,2),
            CoordinateB = new DecimalDegreeCoordinate(3, 4)
        };
        
        controller.Calculate(request);

        mock.Verify(s => s.CalculateDistance(request.CoordinateA, request.CoordinateB, It.IsAny<DistanceCalculators>(), It.IsAny<Lengths>()));
    }

    [Fact]
    public void CalculateThrowsExceptionIfCoordinatesAreNotProvided()
    {
        var distanceCalculatorService = new MockDistanceCalculatorService().Build();
        var controller = new DistanceController(distanceCalculatorService);
        var requestNoCoordinateA = new CalculateDistanceRequest {CoordinateB = new DecimalDegreeCoordinate(1, 2)};
        var requestNoCoordinateB = new CalculateDistanceRequest {CoordinateA = new DecimalDegreeCoordinate(1, 2)};
        
        var noCoordinateA = Record.Exception(() => controller.Calculate(requestNoCoordinateA));
        var noCoordinateB = Record.Exception(() => controller.Calculate(requestNoCoordinateB));

        Assert.NotNull(noCoordinateA);
        Assert.NotNull(noCoordinateB);
    }
}