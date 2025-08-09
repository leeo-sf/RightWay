using AutoMapper;
using FluentAssertions;
using RightWay.Application.Dto;
using RightWay.Application.Extension;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;
using RightWay.Ioc.Configuration;

namespace RightWay.Application.Tests.Mapper;

public class DtoTests
{
    private readonly IMapper mapper;

    public DtoTests() => mapper = AutoMapperConfiguration.RegisterMaps().CreateMapper();

    [Theory]
    [InlineData(0.10, 1.20, PriorityLevelEnum.URGENT, "URGENT", OrderStatusEnum.SEPARATION, "In Separation")]
    [InlineData(0.99, 1.01, PriorityLevelEnum.LOW, "LOW", OrderStatusEnum.TRANSIT, "In Transit")]
    [InlineData(0.81, 1, PriorityLevelEnum.NORMAL, "NORMAL", OrderStatusEnum.PENDING, "Pending")]
    [InlineData(0.10, 1.20, PriorityLevelEnum.URGENT, "URGENT", OrderStatusEnum.DELIVERED, "Delivered")]
    [InlineData(0.67, 1.47, PriorityLevelEnum.LOW, "LOW", OrderStatusEnum.SCHEDULED, "Scheduled")]
    [InlineData(27, 0.45, PriorityLevelEnum.NORMAL, "NORMAL", OrderStatusEnum.FAILED, "Failed")]
    public void Must_Convert_An_Order_ToDto_When_Prompted(float weight, float height, PriorityLevelEnum priorityLevel, string priorityLevelDescription, OrderStatusEnum status, string statusDescription)
    {
        Guid orderId = Guid.NewGuid(), addressId = Guid.NewGuid(), baseAddressId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();

        var address = new Address(addressId, createdAt, updatedIn, 15, null, baseAddressId, null, null) { BaseAddress = new(baseAddressId, createdAt, updatedIn, "06492-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP, "São Paulo", "Sudeste", 3550308, null, null) };
        var order = new Order(orderId, createdAt, updatedIn, weight, height, priorityLevel, status, addressId) { Address = address };

        var dto = mapper.Map<OrderDto>(order);
        dto.Should().NotBeNull();
        dto.PriorityLevel.Should().Be(priorityLevelDescription);
        dto.Status.Should().Be(statusDescription);
        dto.address.Should().NotBeNull();
        dto.address.Uf.Should().Be(StateEnum.SP.GetDescription());
    }
}