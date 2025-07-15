using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Order(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, float Weight, float Height, PriorityLevel PriorityLevel, OrderStatus Status, Guid AddressId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Address Address { get; } = default!;
}