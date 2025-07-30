using FluentAssertions;
using RightWay.Domain.Entity;

namespace RightWay.Domain.Tests.Entities;

public class DriverTests
{
    [Fact]
    public void Must_Create_Driver_With_Valid_Parameters()
    {
        Guid driverId = Guid.NewGuid(), vehicleId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        string name = "Test", driverLincenseNumber = "0891783781", phone = "1191111-2222";

        var driver = new Driver(driverId, createdAt, updatedIn, name, driverLincenseNumber, phone, vehicleId);

        driver.Should().NotBeNull();
        driver.Id.Should().Be(driverId);
        driver.CreatedIn.Should().Be(createdAt);
        driver.UpdatedIn.Should().Be(updatedIn);
        driver.Name.Should().Be(name);
        driver.DriverLincenseNumber.Should().Be(driverLincenseNumber);
        driver.Phone.Should().Be(phone);
        driver.VehicleId.Should().Be(vehicleId);
    }
}