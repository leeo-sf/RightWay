using FluentAssertions;
using MediatR;
using Moq;
using RightWay.Application.Dto;
using RightWay.Application.Request.Order;
using RightWay.Application.Tests.TestData;

namespace RightWay.Application.Tests.Request;

public class OrderDispatchedRequestTests
{
    [Fact]
    public async Task Must_Reach_The_Correct_Handler_When_Called()
    {
        var mockHandler = new Mock<IRequestHandler<OrderDispatchedRequest, Result>>();

        mockHandler.Setup(h =>
            h.Handle(It.IsAny<OrderDispatchedRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result(true));

        var request = new OrderDispatchedRequest(Guid.NewGuid());
        var result = await mockHandler.Object.Handle(request, CancellationToken.None);

        result.Exception.Should().BeNull();
        result.IsSuccess.Should().BeTrue();
        mockHandler.Verify(h =>
            h.Handle(It.IsAny<OrderDispatchedRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}