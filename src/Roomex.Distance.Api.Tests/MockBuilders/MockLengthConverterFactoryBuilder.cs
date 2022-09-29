using Moq;
using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Enums;
using Roomex.Distance.Api.Factories;

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