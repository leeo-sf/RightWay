using FluentAssertions;
using RightWay.Domain.Entity;

namespace RightWay.Domain.Tests.Entities;

public class RouteOrderTests
{
    [Fact]
    public void Must_Create_RouteOrder_With_Valid_Parameters()
    {
        Guid routeOrderId = Guid.NewGuid(), routeId = Guid.NewGuid(), orderId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        int deliveryOrder = 20;

        var routeOrder = new RouteOrder(routeOrderId, createdAt, updatedIn, routeId, orderId, deliveryOrder);

        routeOrder.Should().NotBeNull();
        routeOrder.Id.Should().Be(routeOrderId);
        routeOrder.CreatedIn.Should().Be(createdAt);
        routeOrder.UpdatedIn.Should().Be(updatedIn);
        routeOrder.RouteId.Should().Be(routeId);
        routeOrder.OrderId.Should().Be(orderId);
        routeOrder.DeliveryOrder.Should().Be(deliveryOrder);
    }
}