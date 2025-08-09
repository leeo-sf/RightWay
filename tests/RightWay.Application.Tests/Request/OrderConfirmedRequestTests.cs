using FluentAssertions;
using MediatR;
using Moq;
using RightWay.Application.Request.Order;
using RightWay.Application.Response;
using RightWay.Application.Tests.TestData;

namespace RightWay.Application.Tests.Request;

public class OrderConfirmedRequestTests
{
    [Fact]
    public async Task Must_Reach_The_Correct_Handler_When_Called()
    {
        var mockHandler = new Mock<IRequestHandler<OrderConfirmedRequest, Result<StatusOperationResponse>>>();

        mockHandler.Setup(h =>
            h.Handle(It.IsAny<OrderConfirmedRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new StatusOperationResponse("Orders awaiting separation."));

        var request = new OrderConfirmedRequest(OrderTestData.ValidOrdersToBeCreated);
        var result = await mockHandler.Object.Handle(request, CancellationToken.None);

        result.Value.Should().Be(new StatusOperationResponse("Orders awaiting separation."));
        mockHandler.Verify(h =>
            h.Handle(It.IsAny<OrderConfirmedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}