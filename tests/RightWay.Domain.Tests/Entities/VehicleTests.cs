using FluentAssertions;
using RightWay.Domain.Entity;

namespace RightWay.Domain.Tests.Entities;

public class VehicleTests
{
    [Fact]
    public void Must_Create_Vehicle_With_Valid_Parameters()
    {
        Guid vehicleId = Guid.NewGuid(), driverId = Guid.NewGuid(), routeId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        string plateNumber = "ABC1D2", model = "Celta";
        float capacity = 10f;

        var vehicle = new Vehicle(vehicleId, createdAt, updatedIn, plateNumber, model, capacity, driverId, routeId);

        vehicle.Should().NotBeNull();
        vehicle.Id.Should().Be(vehicleId);
        vehicle.CreatedIn.Should().Be(createdAt);
        vehicle.UpdatedIn.Should().Be(updatedIn);
        vehicle.PlateNumber.Should().Be(plateNumber);
        vehicle.Model.Should().Be(model);
        vehicle.Capacity.Should().Be(capacity);
        vehicle.DriverId.Should().Be(driverId);
        vehicle.RouteId.Should().Be(routeId);
    }
}