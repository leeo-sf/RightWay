using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RightWay.Application.Config;
using RightWay.Application.Tests.TestData;
using RightWay.Ioc.Configuration;

namespace RightWay.Application.Tests.Config;

public class AppConfigurationTests
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;

    public AppConfigurationTests()
    {
        _services = new ServiceCollection();
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(AppConfigurationTestData.AppConfigurationTestSettings()!)
            .Build();
    }

    [Fact]
    public void Must_Contain_Credentials_When_Invoked()
    {
        _services.ConfigureServices(_configuration);
        var provaider = _services.BuildServiceProvider();
        var options = provaider.GetRequiredService<AppConfiguration>();

        options.RabbitMQ.HostName.Should().NotBeNullOrEmpty();
        options.RabbitMQ.Password.Should().NotBeNullOrEmpty();
        options.RabbitMQ.UserName.Should().NotBeNullOrEmpty();
        options.RabbitMQ.VirtualHost.Should().NotBeNullOrEmpty();
        options.RabbitMQ.Queues.RouteCalculation.Should().NotBeNullOrEmpty();
    }
}