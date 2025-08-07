namespace RightWay.Application.Tests.TestData;

internal static class AppConfigurationTestData
{
    public static Dictionary<string, string> AppConfigurationTestSettings()
        => new Dictionary<string, string>
        {
            { "Service:RabbitMQ:HostName", "HostName-Test" },
            { "Service:RabbitMQ:Password", "Password-Test" },
            { "Service:RabbitMQ:UserName", "UserName-Test" },
            { "Service:RabbitMQ:VirtualHost", "VirtualHost-Test" },
            { "Service:RabbitMQ:Queues:RouteCalculation", "Queue-RouteCalculation-Test" }
        };
}