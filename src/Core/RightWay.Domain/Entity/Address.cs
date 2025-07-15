using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Address(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, int Number, State Uf, float Latitude, Guid OrderId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Order Order { get; } = default!;
}