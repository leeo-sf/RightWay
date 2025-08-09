using MediatR;
using RightWay.Application.Dto;

namespace RightWay.Application.Request.Order;

public record OrdersAwaitingSeparationRequest()
    : IRequest<Result<List<OrderDto>>>;