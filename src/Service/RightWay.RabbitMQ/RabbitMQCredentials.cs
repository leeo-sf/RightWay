namespace RightWay.RabbitMQ;

public record RabbitMQCredentials(string HostName, string Password, string UserName, string VirtualHost = "/");