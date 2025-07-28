using MediatR;
using RightWay.Application.Contract;
using RightWay.Application.Response;
using RightWay.Domain.Enum;

namespace RightWay.Application.Request;

public record OrderConfirmedRequest(List<OrderContract> Orders)
    : IRequest<Result<StatusOperationResponse>>;