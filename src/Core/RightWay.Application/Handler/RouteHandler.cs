using MediatR;
using RightWay.Application.Request;

namespace RightWay.Application.Handler;

internal class RouteHandler
    : IRequestHandler<RouteCalculationRequest, Result>
{
    public async Task<Result> Handle(RouteCalculationRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}