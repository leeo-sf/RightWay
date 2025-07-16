using RightWay.Domain.Entity.Base;

namespace RightWay.Domain.Entity;

public record RouteOrder(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, Guid RouteId, Guid OrderId, int DeliveryOrder)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Route Route { get; } = default!;
    public Order Order { get; } = default!;
}