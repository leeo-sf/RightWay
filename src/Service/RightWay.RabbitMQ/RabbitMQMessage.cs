namespace RightWay.RabbitMQ;

public record RabbitMQMessage<T>(string HostName, string Password, string UserName, string VirtualHost, string QueueName, T Message)
{
    public static RabbitMQMessage<T> CreateMessage(RabbitMQCredentials credentials, string queueName, T Message)
        => new(credentials.HostName, credentials.Password, credentials.UserName, credentials.VirtualHost, queueName, Message);
}