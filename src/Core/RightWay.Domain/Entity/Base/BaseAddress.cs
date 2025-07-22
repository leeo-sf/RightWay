using RightWay.Domain.Enum;

namespace RightWay.Domain.Entity.Base;

public record BaseAddress(Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string ZipCode, string PublicPlace, string Neighborhood, string Locality, StateEnum Uf, string State, string Region, int MunicipalCode, float? Latitude, float? Longitude) 
    : BaseEntity(Id, CreatedIn, UpdatedIn)
{
    public ICollection<Address> Addresses { get; } = default!;
}