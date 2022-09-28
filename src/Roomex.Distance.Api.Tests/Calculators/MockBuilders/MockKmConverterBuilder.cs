using Moq;
using Roomex.Distance.Api.Converters;

namespace Roomex.Distance.Api.Tests.Calculators.MockBuilders;

public class MockKmConverterBuilder
{
    private readonly Mock<IKmConverter> _mock;
    private double _returnValue;

    public MockKmConverterBuilder()
    {
        _mock = new Mock<IKmConverter>();
        _mock.Setup(converter => converter.Convert(It.IsAny<double>()))
            .Returns(() => _returnValue);
    }

    public MockKmConverterBuilder WithReturnValue(double returnValue)
    {
        _returnValue = returnValue;
        return this;
    }

    public IKmConverter Build()
    {
        return _mock.Object;
    }
}