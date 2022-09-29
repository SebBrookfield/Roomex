using Moq;

namespace Roomex.Distance.Api.Tests;

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
}