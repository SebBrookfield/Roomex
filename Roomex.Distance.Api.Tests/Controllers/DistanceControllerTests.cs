using Roomex.Distance.Api.Controllers;
using Xunit;

namespace Roomex.Distance.Api.Tests.Controllers;

public class DistanceControllerTests
{
    [Fact]
    public void DistanceControllerDoesNotThrow()
    {
        Assert.Null(Record.Exception(() => new DistanceController()));
    }
}