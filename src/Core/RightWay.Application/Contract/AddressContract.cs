using RightWay.Domain.Enum;

namespace RightWay.Application.Contract;

public class AddressContract
{
    public string ZipCode { get; init; } = default!;
    public string PublicPlace { get; init; } = default!;
    public string Neighborhood { get; init; } = default!;
    public string Locality { get; init; } = default!;
    public StateEnum Uf { get; init; } = default!;
    public string State { get; init; } = default!;
    public string Region { get; init; } = default!;
    public int MunicipalCode { get; init; } = default!;
    public int Number { get; init; } = default!;
    public string? Complement { get; init; } = default!;
}