using RightWay.Domain.Entity.Base;

namespace RightWay.Domain.Entity;

public record Address(Guid Id, DateTime CreatedIn, DateTime UpdatedIn, int Number, string? Complement, Guid BaseAddressId, Guid? OrderId, Guid? RouteId)
    : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public BaseAddress BaseAddress { get; init; } = default!;
    public Order? Order { get; } = default!;
    public Route? Route { get; } = default!;
}