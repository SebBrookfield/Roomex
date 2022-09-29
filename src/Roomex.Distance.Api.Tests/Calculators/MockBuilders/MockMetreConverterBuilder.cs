using Moq;
using Roomex.Distance.Api.Converters;

namespace Roomex.Distance.Api.Tests.Calculators.MockBuilders;

public class MockMetreConverterBuilder
{
    private readonly Mock<ILengthConverter> _mock;
    private double _returnValue;

    public MockMetreConverterBuilder()
    {
        _mock = new Mock<ILengthConverter>();
        _mock.Setup(converter => converter.ConvertFromMetres(It.IsAny<double>()))
            .Returns(() => _returnValue);
    }

    public MockMetreConverterBuilder WithReturnValue(double returnValue)
    {
        _returnValue = returnValue;
        return this;
    }

    public ILengthConverter Build()
    {
        return _mock.Object;
    }
}