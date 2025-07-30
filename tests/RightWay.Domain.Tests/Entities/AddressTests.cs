using FluentAssertions;
using RightWay.Domain.Entity;

namespace RightWay.Domain.Tests.Entities;

public class AddressTests
{
    [Theory]
    [InlineData(10, null)]
    [InlineData(55, "Complement test")]
    public void Must_Create_Address_With_Valid_Parameters(int number, string? complement)
    {
        Guid addressId = Guid.NewGuid(), baseAddressId = Guid.NewGuid(), orderId = Guid.NewGuid(), routeId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();

        var driver = new Address(addressId, createdAt, updatedIn, number, complement, baseAddressId, orderId, routeId);

        driver.Should().NotBeNull();
        driver.Id.Should().Be(addressId);
        driver.CreatedIn.Should().Be(createdAt);
        driver.UpdatedIn.Should().Be(updatedIn);
        driver.Number.Should().Be(number);
        driver.Complement.Should().Be(complement);
        driver.BaseAddressId.Should().Be(baseAddressId);
        driver.OrderId.Should().Be(orderId);
        driver.RouteId.Should().Be(routeId);
    }
}