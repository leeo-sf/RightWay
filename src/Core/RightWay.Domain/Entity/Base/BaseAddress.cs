using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity.Base;

public sealed record BaseAddress(Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, string Locality, StateEnum Uf, string State, string Region, int MunicipalCode, double? Latitude, double? Longitude) 
    : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public ICollection<Address> Addresses { get; } = default!;
}