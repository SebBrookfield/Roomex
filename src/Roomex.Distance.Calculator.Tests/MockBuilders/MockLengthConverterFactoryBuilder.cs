using Moq;
using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Factories;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class MockLengthConverterFactoryBuilder : BaseMockBuilder<ILengthConverterFactory>
{
    private IMetreConverter _metreConverter;

    public MockLengthConverterFactoryBuilder()
    {
        _metreConverter = new MockLengthConverterBuilder().Build();

        Mock.Setup(f => f.GetMetreConverter(It.IsAny<Lengths>()))
            .Returns(() => _metreConverter);
    }

    public MockLengthConverterFactoryBuilder WithMetreConverter(IMetreConverter metreConverter)
    {
        _metreConverter = metreConverter;
        return this;
    }
}