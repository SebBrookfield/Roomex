using Moq;
using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class MockDistanceCalculatorBuilder : BaseMockBuilder<ICoordinateDistanceCalculator>
{
    private double _distance;

    public MockDistanceCalculatorBuilder()
    {
        Mock.Setup(c => c.CalculateDistance(It.IsAny<DecimalDegreeCoordinate>(), It.IsAny<DecimalDegreeCoordinate>(),
                It.IsAny<IMetreConverter>()))
            .Returns(() => _distance);
    }

    public MockDistanceCalculatorBuilder WithDistance(double distance)
    {
        _distance = distance;
        return this;
    }
}