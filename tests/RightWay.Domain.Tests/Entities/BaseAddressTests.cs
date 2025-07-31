using FluentAssertions;
using RightWay.Domain.Entity.Base;
using RightWay.Domain.Enum;

namespace RightWay.Domain.Tests.Entities;

public class BaseAddressTests
{
    [Theory]
    [InlineData("01001-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP, "São Paulo", "Sudeste", 3550308, null, null)]
    [InlineData("01001-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP, "São Paulo", "Sudeste", 3550308, -23.55031, -46.634201)]
    [InlineData("01001-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP, "São Paulo", "Sudeste", 3550308, null, -46.634201)]
    [InlineData("01001-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP, "São Paulo", "Sudeste", 3550308, -23.55031, null)]
    public void Must_Create_BaseAddress_With_Valid_Parameters(string zipCode, string publicPlace, string neighborhood, string locality, StateEnum uf, string state, string region, int municipalCode, double? latitude, double? longitude)
    {
        Guid baseAddressId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();

        var baseAddress = new BaseAddress(baseAddressId, createdAt, updatedIn, zipCode, publicPlace, neighborhood, locality, uf, state, region, municipalCode, latitude, longitude);

        baseAddress.Should().NotBeNull();
        baseAddress.Id.Should().Be(baseAddressId);
        baseAddress.CreatedIn.Should().Be(createdAt);
        baseAddress.UpdatedIn.Should().Be(updatedIn);
        baseAddress.ZipCode.Should().Be(zipCode);
        baseAddress.PublicPlace.Should().Be(publicPlace);
        baseAddress.Neighborhood.Should().Be(neighborhood);
        baseAddress.Locality.Should().Be(locality);
        baseAddress.Uf.Should().Be(uf);
        baseAddress.State.Should().Be(state);
        baseAddress.Region.Should().Be(region);
        baseAddress.MunicipalCode.Should().Be(municipalCode);
        baseAddress.Latitude.Should().Be(latitude);
        baseAddress.Longitude.Should().Be(longitude);
    }
}