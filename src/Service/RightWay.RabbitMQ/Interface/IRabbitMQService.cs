namespace RightWay.RabbitMQ.Interface;

public interface IRabbitMQService
{
    Task PublisherAsync<T>(RabbitMQMessage<T> data);
}