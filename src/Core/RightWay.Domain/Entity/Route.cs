using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Route : BaseEntity
{
    public DateTime EstimatedStart { get; }
    public DateTime EstimatedEnd { get; }
    public float TotalDistanceKm { get; }
    public RouteStatusEnum Status { get; }
    public Guid DepartureAddressId { get; }
    public Guid VehicleId { get; }
    public Address DepartureAddress { get; } = default!;
    public Vehicle Vehicle { get; } = default!;
    public ICollection<RouteOrder> Orders { get; } = default!;

    public Route(Guid id, DateTime createdIn, DateTime updatedIn, DateTime estimatedStart, DateTime estimatedEnd, float totalDistanceKm, RouteStatusEnum status, Guid departureAddressId, Guid vehicleId)
        : base(id, createdIn, updatedIn)
    {
        if (IsValidStartAndEndPlanning(estimatedStart, estimatedEnd))
            throw new ArgumentException("Start date and time not permitted.");

        EstimatedStart = estimatedStart;
        EstimatedEnd = estimatedEnd;
        TotalDistanceKm = totalDistanceKm;
        Status = status;
        DepartureAddressId = departureAddressId;
        VehicleId = vehicleId;
    }

    private bool IsValidStartAndEndPlanning(DateTime estimatedStart, DateTime estimatedEnd)
        => estimatedStart < DateTime.Now || estimatedStart >= estimatedEnd
            || (estimatedEnd - estimatedStart).TotalHours < 2 || (estimatedEnd - estimatedStart).TotalHours > 8;
}