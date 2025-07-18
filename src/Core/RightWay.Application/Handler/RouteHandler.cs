using MediatR;
using RightWay.Application.Config;
using RightWay.Application.Contract.RabbitMQ;
using RightWay.Application.Request;
using RightWay.Application.Response;
using RightWay.RabbitMQ.Interface;

namespace RightWay.Application.Handler;

public class RouteHandler
    : IRequestHandler<RouteCalculationRequest, Result<StatusOperationResponse>>
{
    private readonly AppConfiguration _appConfiguration;
    private readonly IRabbitMQService _rabbitMQService;

    public RouteHandler(
        AppConfiguration appConfiguration,
        IRabbitMQService rabbitMQService)
    {
        _appConfiguration = appConfiguration;
        _rabbitMQService = rabbitMQService;
    }

    public async Task<Result<StatusOperationResponse>> Handle(RouteCalculationRequest request, CancellationToken cancellationToken)
    {
        await _rabbitMQService.PublisherAsync<RouteCalculationContract>
            (new(_appConfiguration.RabbitMQ.HostName, _appConfiguration.RabbitMQ.Password, _appConfiguration.RabbitMQ.UserName, _appConfiguration.RabbitMQ.VirtualHost, _appConfiguration.RabbitMQ.Queues.RouteCalculation, new(request.GroupOrderLimit, request.TotalRouteDistanceLimitInKm, request.Addresses)));
        return new StatusOperationResponse("The best delivery route will be calculated within a few moments.");
    }
}