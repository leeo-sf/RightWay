using MediatR;
using RightWay.Application.Contract;
using RightWay.Application.Response;

namespace RightWay.Application.Request.Order;

public record OrderConfirmedRequest(List<OrderContract> Orders)
    : IRequest<Result<StatusOperationResponse>>;