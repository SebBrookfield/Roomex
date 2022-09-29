using Moq;
using Roomex.Distance.Api.Calculators;
using Roomex.Distance.Api.Enums;
using Roomex.Distance.Api.Factories;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class MockDistanceCalculatorFactoryBuilder : BaseMockBuilder<IDistanceCalculatorFactory>
{
    private ICoordinateDistanceCalculator _calculator;

    public MockDistanceCalculatorFactoryBuilder()
    {
        _calculator = new MockDistanceCalculatorBuilder().Build();

        Mock.Setup(f => f.GetDistanceCalculator(It.IsAny<DistanceCalculators>()))
            .Returns(() => _calculator);
    }

    public MockDistanceCalculatorFactoryBuilder WithCalculator(ICoordinateDistanceCalculator calculator)
    {
        _calculator = calculator;
        return this;
    }
}