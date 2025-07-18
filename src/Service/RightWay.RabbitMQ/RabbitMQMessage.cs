namespace RightWay.RabbitMQ;

public record RabbitMQMessage<T>(string HostName, string Password, string UserName, string VirtualHost, string QueueName, T Message);