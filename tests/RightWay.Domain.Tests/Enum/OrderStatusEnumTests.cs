using RightWay.Application.Extension;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Tests.Enums;

public class OrderStatusEnumTests
{
    [Theory]
    [InlineData(OrderStatusEnum.SEPARATION, 0, "In Separation")]
    [InlineData(OrderStatusEnum.PENDING, 1, "Pending")]
    [InlineData(OrderStatusEnum.SCHEDULED, 2, "Scheduled")]
    [InlineData(OrderStatusEnum.TRANSIT, 3, "In Transit")]
    [InlineData(OrderStatusEnum.DELIVERED, 4, "Delivered")]
    [InlineData(OrderStatusEnum.FAILED, 5, "Failed")]
    public void Value_And_Description_Must_Match(OrderStatusEnum orderStatus, int expectedValue, string expectedDescription)
    {
        var value = (int)orderStatus;
        var description = orderStatus.GetDescription();

        Assert.Equal(expectedDescription, description);
        Assert.Equal(expectedValue, value);
    }
}