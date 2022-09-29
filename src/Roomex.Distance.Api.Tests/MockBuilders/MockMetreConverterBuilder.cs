using Moq;
using Roomex.Distance.Api.Converters;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class MockMetreConverterBuilder : BaseMockBuilder<ILengthConverter>
{
    private double _returnValue;

    public MockMetreConverterBuilder()
    {
        Mock.Setup(converter => converter.ConvertFromMetres(It.IsAny<double>()))
            .Returns(() => _returnValue);
    }

    public MockMetreConverterBuilder WithReturnValue(double returnValue)
    {
        _returnValue = returnValue;
        return this;
    }
}