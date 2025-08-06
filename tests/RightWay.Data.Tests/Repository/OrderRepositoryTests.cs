using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RightWay.Data.Repository;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;

namespace RightWay.Data.Tests.Repository;

public class OrderRepositoryTests
{
    private readonly DbContextOptions<AppDbContext> _dbContext;

    public OrderRepositoryTests()
        => _dbContext = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("RepoTestDb").Options;

    [Fact]
    public async Task Repository_Should_Add_Entity()
    {
        using var context = new AppDbContext(_dbContext);
        var repository = new OrderRepository(context);

        var order = new Order(Guid.NewGuid(), DateTime.Now.ToUniversalTime(), DateTime.Now.ToUniversalTime(), 10.2f, 1.50f, PriorityLevelEnum.LOW, OrderStatusEnum.SEPARATION, Guid.NewGuid());
        await repository.CreateRangeAsync([order], CancellationToken.None);

        var result = await context.Order.FindAsync(order.Id);
        result.Should().NotBeNull();
        result.Should().Be(order);
    }
}