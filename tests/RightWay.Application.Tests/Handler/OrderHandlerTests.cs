using Moq;
using FluentAssertions;
using RightWay.Application.Handler;
using RightWay.Domain.Interface;
using RightWay.Application.Tests.TestData;
using RightWay.Application.Response;
using RightWay.Application.Request.Order;
using AutoMapper;

namespace RightWay.Application.Tests.Handler;

public class OrderHandlerTests
{
    private readonly Mock<IOrderRepository> mock;
    private readonly Mock<IMapper> mapper;

    public OrderHandlerTests()
    {
        mock = new Mock<IOrderRepository>();
        mapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handler_Must_Create_Order_When_Valid_Command()
    {
        var handler = new OrderHandler(mock.Object, mapper.Object);
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
        var handler = new OrderHandler(mock.Object, mapper.Object);
        var command = new OrdersAwaitingSeparationRequest();
        var response = await handler.Handle(command, CancellationToken.None);

        response.Should().NotBeNull();
        response.Exception.Should().BeNull();
        response.IsSuccess.Should().BeTrue();
    }
}