using MediatR;

namespace RightWay.Application.Request.Order;

public record OrderDispatchedRequest(Guid Id) : IRequest<Result>;