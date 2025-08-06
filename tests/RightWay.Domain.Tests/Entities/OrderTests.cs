using FluentAssertions;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Tests.Entities;

public class OrderTests
{
    [Fact]
    public void Must_Create_Order_With_Valid_Parameters()
    {
        Guid orderId = Guid.NewGuid(), addressId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        float weight = 0.10f, height = 1.5f;
        PriorityLevelEnum priorityLevel = PriorityLevelEnum.NORMAL;
        OrderStatusEnum status = OrderStatusEnum.SEPARATION;

        var order = new Order(orderId, createdAt, updatedIn, weight, height, priorityLevel, status, addressId);

        order.Should().NotBeNull();
        order.Id.Should().Be(orderId);
        order.CreatedIn.Should().Be(createdAt);
        order.UpdatedIn.Should().Be(updatedIn);
        order.Weight.Should().Be(weight);
        order.Height.Should().Be(height);
        order.PriorityLevel.Should().Be(priorityLevel);
        order.Status.Should().Be(status);
        order.AddressId.Should().Be(addressId);
    }
}