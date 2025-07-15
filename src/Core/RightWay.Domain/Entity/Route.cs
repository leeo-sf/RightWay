using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Route(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, DateTime EstimatedStart, DateTime EstimatedEnd, float TotalDistanceKm, RouteStatus Status, Guid VehicleId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Vehicle Vehicle { get; } = default!;
    public ICollection<RouteOrder> Orders { get; } = default!;
}