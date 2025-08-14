using MediatR;
using RightWay.Application.Dto;

namespace RightWay.Application.Request.Order;

public record OrdersReadyToDispatchRequest() : IRequest<Result<List<OrderDto>>>;