namespace RightWay.Application.Config;

public class QueueRabbitMQConfiguration
{
    public string SeparationQueue { get; init; } = default!;
    public string RouteCalculation { get; init; } = default!;
}