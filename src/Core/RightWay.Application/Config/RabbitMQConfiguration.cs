namespace RightWay.Application.Config;

public class RabbitMQConfiguration
{
    public string HostName { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string UserName { get; init; } = default!;
    public string VirtualHost { get; init; } = default!;
    public QueueRabbitMQConfiguration Queues { get; init; } = default!;
}