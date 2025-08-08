using MediatR;
using Moq;
using RightWay.Api.Controllers;
using RightWay.Api.Tests.TestData;
using RightWay.Application.Request.Order;

namespace RightWay.Api.Tests.Controllers;

public class OrderControllerTests
{
    private readonly Mock<IMediator> _mock;

    public OrderControllerTests() => _mock = new Mock<IMediator>();

    [Fact]
    public async Task CreateOrder_Should_Call_Mediator_With_Request()
    {
        var controller = new OrderController(_mock.Object);
        var request = OrderControllerTestData.ValidOrders;
        await controller.RegisterConfirmedOrder(new(request));

        _mock.Verify(m => m.Send(It.IsAny<OrderConfirmedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}