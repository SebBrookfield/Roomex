using Moq;

namespace Roomex.Distance.Api.Tests.MockBuilders;

public class BaseMockBuilder<T> where T : class
{
    protected readonly Mock<T> Mock;

    protected BaseMockBuilder()
    {
        Mock = new Mock<T>();
    }

    public virtual T Build()
    {
        return Mock.Object;
    }

    public virtual T Build(out Mock<T> mock)
    {
        mock = Mock;
        return Mock.Object;
    }
}