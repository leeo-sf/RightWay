using FluentAssertions;
using MediatR;
using Moq;
using RightWay.Application.Dto;
using RightWay.Application.Request.Order;
using RightWay.Application.Tests.TestData.Request;

namespace RightWay.Application.Tests.Request;

public class OrdersAwaitingSeparationRequestTests
{
    [Fact]
    public async Task Must_Reach_The_Correct_Handler_When_Called()
    {
        var mockHandler = new Mock<IRequestHandler<OrdersAwaitingSeparationRequest, Result<List<OrderDto>>>>();

        mockHandler.Setup(h =>
            h.Handle(It.IsAny<OrdersAwaitingSeparationRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(OrderAwaitingSeparationRequestTestsData.OrdersDto());

        var request = new OrdersAwaitingSeparationRequest();
        var result = await mockHandler.Object.Handle(request, CancellationToken.None);

        result.Value.Should().NotBeNull();
        mockHandler.Verify(h =>
            h.Handle(It.IsAny<OrdersAwaitingSeparationRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}