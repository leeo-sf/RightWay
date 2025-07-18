namespace RightWay.Application.Config;

public class AppConfiguration
{
    public RabbitMQConfiguration RabbitMQ { get; init; } = default!;
}