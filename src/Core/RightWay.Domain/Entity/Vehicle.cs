using RightWay.Domain.Entity.Base;

namespace RightWay.Domain.Entity;

public record Vehicle(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string PlateNumber, string Model, float Capacity, Guid DriverId) : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Driver Driver { get; set; } = default!;
}