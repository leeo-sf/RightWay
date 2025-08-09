using MediatR;

namespace RightWay.Application.Request.Order;

public record OrderSeparatedRequest(Guid Id)
    : IRequest<Result>;