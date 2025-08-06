using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RightWay.Data;
using RightWay.Domain.Interface;
using RightWay.Ioc.Configuration;
using RightWay.Ioc.Tests.TestData;
using RightWay.RabbitMQ.Interface;

namespace RightWay.Ioc.Tests;

public class DependenciesTests
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;

    public DependenciesTests()
    {
        _services = new ServiceCollection();
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(DependenciesTestData.ServiceTestSettings()!)
            .Build();
    }

    [Fact]
    public void Should_Resolve_All_Core_Services()
    {
        _services.AddDbContextConfiguration(_configuration);
        _services.ConfigureServices(_configuration);
        var provaider = _services.BuildServiceProvider();

        provaider.GetService<IRabbitMQService>().Should().NotBeNull();
        provaider.GetService<IOrderRepository>().Should().NotBeNull();
    }

    [Fact]
    public void Database_Must_Be_Registered()
    {
        _services.AddDbContextConfiguration(_configuration);
        var provaider = _services.BuildServiceProvider();

        provaider.GetService<AppDbContext>().Should().NotBeNull();
    }
}