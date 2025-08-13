using FluentAssertions;
using MediatR;
using Moq;
using RightWay.Application.Dto;
using RightWay.Application.Request.Order;
using RightWay.Application.Tests.TestData;

namespace RightWay.Application.Tests.Request;

public class OrdersReadyToDispatchRequestTests
{

    [Fact]
    public async Task Must_Reach_The_Correct_Handler_When_Called()
    {
        var mockHandler = new Mock<IRequestHandler<OrdersReadyToDispatchRequest, Result<List<OrderDto>>>>();

        mockHandler.Setup(h =>
            h.Handle(It.IsAny<OrdersReadyToDispatchRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(OrderTestData.OrdersDto());

        var request = new OrdersReadyToDispatchRequest();
        var result = await mockHandler.Object.Handle(request, CancellationToken.None);

        result.Value!.Should().NotBeNull();
        mockHandler.Verify(h =>
            h.Handle(It.IsAny<OrdersReadyToDispatchRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}