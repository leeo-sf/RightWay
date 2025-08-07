using RightWay.Domain.Enum;

namespace RightWay.Domain.Tests.Enum;

public class PriorityLevelEnumTests
{
    [Theory]
    [InlineData(PriorityLevelEnum.LOW, 0)]
    [InlineData(PriorityLevelEnum.NORMAL, 1)]
    [InlineData(PriorityLevelEnum.URGENT, 2)]
    public void Value_Must_Match(PriorityLevelEnum priorityLevel, int expectedValue)
    {
        var value = (int)priorityLevel;

        Assert.Equal(expectedValue, value);
    }
}