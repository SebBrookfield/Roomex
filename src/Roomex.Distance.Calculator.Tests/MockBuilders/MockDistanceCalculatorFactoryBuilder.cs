using Moq;
using Roomex.Distance.Calculator.Calculators;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Factories;

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