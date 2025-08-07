using RightWay.Domain.Enum;

namespace RightWay.Domain.Tests.Enum;

public class RouteStatusEnumTests
{
    [Theory]
    [InlineData(RouteStatusEnum.PLANNED, 0)]
    [InlineData(RouteStatusEnum.PROGRESS, 1)]
    [InlineData(RouteStatusEnum.COMPLETED, 2)]
    [InlineData(RouteStatusEnum.CANCELLED, 3)]
    public void Value_Must_Match(RouteStatusEnum routeStatus, int expectedValue)
    {
        var value = (int)routeStatus;

        Assert.Equal(expectedValue, value);
    }
}