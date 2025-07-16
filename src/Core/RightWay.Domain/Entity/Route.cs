using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Route(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, DateTime EstimatedStart, DateTime EstimatedEnd, float TotalDistanceKm, RouteStatusEnum Status, Guid DepartureAddressId, Guid VehicleId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Address DepartureAddress { get; } = default!;
    public Vehicle Vehicle { get; } = default!;
    public ICollection<RouteOrder> Orders { get; } = default!;
}