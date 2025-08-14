using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RightWay.Data.Repository;
using RightWay.Data.Tests.TestData;
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
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var order = OrderRepositoryTestData.Order();
        await repository.CreateRangeAsync([order], CancellationToken.None);

        var result = await context.Order.ToListAsync();
        result.Should().NotBeNull();
        result.Count.Should().Be(1);
        result.FirstOrDefault().Should().Be(order);
    }

    [Fact]
    public async Task Must_Add_Entities_When_Prompted()
    {
        using var context = new AppDbContext(_dbContext);
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var orders = OrderRepositoryTestData.Orders().AsEnumerable();
        await repository.CreateRangeAsync(orders, CancellationToken.None);

        var result = await context.Order.ToListAsync();
        result.Should().NotBeNull();
        result.Count.Should().Be(orders.Count());
    }

    [Fact]
    public async Task Must_Return_Order_By_Id_When_The_Order_Exists()
    {
        using var context = new AppDbContext(_dbContext);
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var order = OrderRepositoryTestData.Order();
        await repository.CreateRangeAsync([order], CancellationToken.None);

        var result = await repository.GetByIdAsync(order.Id, CancellationToken.None);
        result.Should().NotBeNull();
        result.Id.Should().Be(order.Id);
        result.Address.Should().NotBeNull();
        result.Address.Id.Should().Be(order.AddressId);
        result.Address.BaseAddress.Should().NotBeNull();
        result.Address.BaseAddress.Id.Should().Be(order.Address.BaseAddressId);
    }

    [Fact]
    public async Task Should_Not_Return_Order_By_Id_When_The_Order_Not_Exist()
    {
        using var context = new AppDbContext(_dbContext);
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var order = OrderRepositoryTestData.Order();
        await repository.CreateRangeAsync([order], CancellationToken.None);

        var result = await repository.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);
        result.Should().BeNull();
    }

    [Theory]
    [InlineData(OrderStatusEnum.SEPARATION)]
    [InlineData(OrderStatusEnum.EXPEDITION)]
    [InlineData(OrderStatusEnum.DISPATCH)]
    [InlineData(OrderStatusEnum.TRANSIT)]
    [InlineData(OrderStatusEnum.DELIVERED)]
    [InlineData(OrderStatusEnum.FAILED)]
    public async Task Must_Return_OrdersInThe_InformedStatus_When_ThereAreOrders_InThe_DesiredStatus(OrderStatusEnum desiredStatus)
    {
        using var context = new AppDbContext(_dbContext);
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var orders = OrderRepositoryTestData.Orders().AsEnumerable();
        await repository.CreateRangeAsync(orders, CancellationToken.None);

        var result = await repository.GetOrdersByStatusAsync(desiredStatus, CancellationToken.None);
        result.Should().NotBeNull();
        result.Count.Should().BeGreaterThan(0);
        result.Should().OnlyContain(x => x.Status == desiredStatus);
    }

    [Theory]
    [InlineData(OrderStatusEnum.SEPARATION)]
    [InlineData(OrderStatusEnum.EXPEDITION)]
    [InlineData(OrderStatusEnum.DISPATCH)]
    [InlineData(OrderStatusEnum.TRANSIT)]
    [InlineData(OrderStatusEnum.DELIVERED)]
    [InlineData(OrderStatusEnum.FAILED)]
    public async Task Should_Not_Return_Orders_InThe_InformedStatus_When_ThereAreNo_OrdersInThe_DesiredStatus(OrderStatusEnum desiredStatus)
    {
        using var context = new AppDbContext(_dbContext);
        context.Database.EnsureDeleted();
        var repository = new OrderRepository(context);

        var orders = OrderRepositoryTestData.Orders().Where(x => x.Status != desiredStatus).ToList().AsEnumerable();
        await repository.CreateRangeAsync(orders, CancellationToken.None);

        var result = await repository.GetOrdersByStatusAsync(desiredStatus, CancellationToken.None);
        result.Should().NotBeNull();
        result.Count.Should().Be(0);
        result.Should().BeNullOrEmpty();
    }
}