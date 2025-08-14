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

    [Fact]
    public async Task Must_Call_The_Mediator_ToUpdateOrder_When_Requested()
    {
        var controller = new OrderController(_mock.Object);
        var request = Guid.NewGuid();
        await controller.MarkOrderAsSeparatedAsync(request);

        _mock.Verify(m => m.Send(It.IsAny<OrderSeparatedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Must_Call_The_Mediator_ToSeek_A_Pending_Separation_When_Requested()
    {
        var controller = new OrderController(_mock.Object);
        await controller.OrdersAwaitingSeparationAsync();

        _mock.Verify(m => m.Send(It.IsAny<OrdersAwaitingSeparationRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Must_Call_The_Mediator_ToSeek_Expedition_Orders_When_Requested()
    {
        var controller = new OrderController(_mock.Object);
        await controller.OrdersReadyToDispatchAsync();

        _mock.Verify(m => m.Send(It.IsAny<OrdersReadyToDispatchRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Must_Call_The_Mediator_ToUpdateOrder_ToDispatched_When_Requested()
    {
        var controller = new OrderController(_mock.Object);
        var request = Guid.NewGuid();
        await controller.MarkOrderDispatchedAsAsync(request);

        _mock.Verify(m => m.Send(It.IsAny<OrderDispatchedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}