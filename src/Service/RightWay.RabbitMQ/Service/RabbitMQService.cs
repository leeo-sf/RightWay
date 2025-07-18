using Newtonsoft.Json;
using RabbitMQ.Client;
using RightWay.RabbitMQ.Interface;
using System.Text;

namespace RightWay.RabbitMQ.Service;

public class RabbitMQService : IRabbitMQService
{
    public async Task PublisherAsync<T>(RabbitMQMessage<T> data)
    {
        var factory = new ConnectionFactory
        {
            HostName = data.HostName,
            UserName = data.UserName,
            Password = data.Password,
            VirtualHost = data.VirtualHost,
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: data.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var messageJson = JsonConvert.SerializeObject(data.Message);
        var body = Encoding.UTF8.GetBytes(messageJson);

        await Task.Run(() => channel.BasicPublish(exchange: "", routingKey: data.QueueName, basicProperties: null, body: body));
    }
}