using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity;

public record Address(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, string Locality, StateEnum Uf, string State, string Region, int Number, int MunicipalCode, float Latitude, Guid? OrderId, Guid? RouteId)
        : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public Order? Order { get; } = default!;
    public Route? Route { get; } = default!;
}