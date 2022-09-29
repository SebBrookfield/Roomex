using Moq;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Models;
using Roomex.Distance.Calculator.Services;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class MockDistanceCalculatorService
{
    private readonly Mock<IDistanceCalculatorService> _mock;
    private double _distance;

    public MockDistanceCalculatorService()
    {
        _mock = new Mock<IDistanceCalculatorService>();

        _mock.Setup(s => s.CalculateDistance(It.IsAny<DecimalDegreeCoordinate>(),
                It.IsAny<DecimalDegreeCoordinate>(),
                It.IsAny<DistanceCalculators>(),
                It.IsAny<Lengths>()))
            .Returns(() => _distance);
    }

    public MockDistanceCalculatorService WithDistance(double distance)
    {
        _distance = distance;
        return this;
    }

    public IDistanceCalculatorService Build()
    {
        return _mock.Object;
    }

    public IDistanceCalculatorService Build(out Mock<IDistanceCalculatorService> mock)
    {
        mock = _mock;
        return _mock.Object;
    }
}