using Moq;
using FluentAssertions;
using RightWay.Application.Handler;
using RightWay.Domain.Interface;
using RightWay.Application.Tests.TestData;
using RightWay.Application.Response;
using RightWay.Application.Request.Order;
using AutoMapper;
using RightWay.Domain.Enum;
using RightWay.Ioc.Configuration;
using RightWay.Domain.Entity;

namespace RightWay.Application.Tests.Handler;

public class OrderHandlerTests
{
    private readonly Mock<IOrderRepository> mock;
    private readonly IMapper mapper;

    public OrderHandlerTests()
    {
        mock = new Mock<IOrderRepository>();
        mapper = AutoMapperConfiguration.RegisterMaps().CreateMapper();
    }

    [Fact]
    public async Task Handler_Must_Create_Order_When_Valid_Command()
    {
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderConfirmedRequest(OrderTestData.ValidOrdersToBeCreated);
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value.Should().NotBeNull();
        response.Value.Should().BeOfType<StatusOperationResponse>();
        response.Value.Message.Should().Be("Orders awaiting separation.");
    }

    [Fact]
    public async Task Handler_Must_Return_A_ListOf_Orders_AwaitingPicking_When_The_Command_IsValid()
    {
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrdersAwaitingSeparationRequest();
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task Handler_Must_Return_OrderNotFound_When_Id_Does_Not_Exists()
    {
        mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync((Order?)null);
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderSeparatedRequest(Guid.NewGuid());
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().NotBeNull();
        response.Exception.Message.Should().Be("Order not located");
        response.Exception.Should().BeOfType<KeyNotFoundException>();
        response.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Handler_Must_Return_Order_Has_AlreadyBeen_Separated_When_StatusIsNot_Separation()
    {
        var order = OrderTestData.Orders().Where(x => x.Status != OrderStatusEnum.SEPARATION).FirstOrDefault();
        mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync(order);
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderSeparatedRequest(Guid.NewGuid());
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().NotBeNull();
        response.Exception.Message.Should().Be("Order has already been separated");
        response.Exception.Should().BeOfType<ApplicationException>();
        response.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Handler_Must_Return_ListOfOrders_InDispatch_When_ThereAre_Orders_InDispatch()
    {
        mock.Setup(x => x.GetOrdersByStatusAsync(It.IsAny<OrderStatusEnum>(), CancellationToken.None))
            .ReturnsAsync(OrderTestData.Orders().Where(x => x.Status == OrderStatusEnum.EXPEDITION).ToList());
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrdersReadyToDispatchRequest();
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task Handler_Must_Return_EmptyList_When_ThereAre_NoOrders_InDispatch()
    {
        mock.Setup(x => x.GetOrdersByStatusAsync(It.IsAny<OrderStatusEnum>(), CancellationToken.None))
            .ReturnsAsync([]);
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrdersReadyToDispatchRequest();
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
        response.Value!.Count.Should().Be(0);
    }

    [Fact]
    public async Task Handler_Must_Return_OrderNotFound_When_Id_DoesNot_Exists_ToChange_Dispatched_Order()
    {
        mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync((Order?)null);
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderDispatchedRequest(Guid.NewGuid());
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().NotBeNull();
        response.Exception.Message.Should().Be("Order not located");
        response.Exception.Should().BeOfType<KeyNotFoundException>();
        response.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Handler_Must_Return_Order_Has_AlreadyBeen_Dispatched_When_StatusIsNot_Expedition()
    {
        mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync(OrderTestData.Orders().Where(x => x.Status != OrderStatusEnum.EXPEDITION).FirstOrDefault());
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderDispatchedRequest(Guid.NewGuid());
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().NotBeNull();
        response.Exception.Message.Should().Be("Order has already been dispatched");
        response.Exception.Should().BeOfType<ApplicationException>();
        response.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Handler_Must_ChangeOrder_ToDispatched_When_TheIdExists_And_IsInDispatchStatus()
    {
        mock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync(OrderTestData.Orders().Where(x => x.Status == OrderStatusEnum.EXPEDITION).FirstOrDefault());
        var handler = new OrderHandler(mock.Object, mapper);
        var command = new OrderDispatchedRequest(Guid.NewGuid());
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
    }
}