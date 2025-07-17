using RightWay.Domain.Enum;

namespace RightWay.Application.Request;

public record AddressRequest
    (string ZipCode, string PublicPlace, string Neighborhood, string Locality, StateEnum Uf, string State, string Region, int Number, int MunicipalCode);