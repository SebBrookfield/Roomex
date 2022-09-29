using Moq;
using Roomex.Distance.Calculator.Calculators;
using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.Models;

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