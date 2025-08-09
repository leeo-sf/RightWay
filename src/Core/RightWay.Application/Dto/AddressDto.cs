using RightWay.Domain.Enum;

namespace RightWay.Application.Dto;

public record AddressDto(Guid Id, string ZipCode, string PublicPlace, string Neighborhood, string Locality, string Uf, string State, string Region, int MunicipalCode, int Number, string? Complement);