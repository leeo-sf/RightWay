using FluentAssertions;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;
using RightWay.Domain.Tests.TestData;

namespace RightWay.Domain.Tests.Entities;

public class RouteTests
{
    [Theory]
    [MemberData(nameof(RouteTestData.ValidDate), MemberType = typeof(RouteTestData))]
    public void Must_Create_Route_With_Valid_Parameters(DateTime estimatedStart, DateTime estimatedEnd)
    {
        Guid routeId = Guid.NewGuid(), departureAddressId = Guid.NewGuid(), vehicleId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        var status = RouteStatusEnum.PLANNED;
        var totalDistanceKm = 10.2f;

        var route = new Route(routeId, createdAt, updatedIn, estimatedStart, estimatedEnd, totalDistanceKm, status, departureAddressId, vehicleId);
        
        route.Should().NotBeNull();
        route.Id.Should().Be(routeId);
        route.CreatedIn.Should().Be(createdAt);
        route.UpdatedIn.Should().Be(updatedIn);
        route.EstimatedStart.Should().Be(estimatedStart);
        route.EstimatedEnd.Should().Be(estimatedEnd);
        route.TotalDistanceKm.Should().Be(totalDistanceKm);
        route.Status.Should().Be(status);
        route.DepartureAddressId.Should().Be(departureAddressId);
        route.VehicleId.Should().Be(vehicleId);
    }

    [Theory]
    [MemberData(nameof(RouteTestData.InvalidDate), MemberType = typeof(RouteTestData))]
    public void No_Must_Create_Route_With_Invalid_Planning_Dates(DateTime estimatedStart, DateTime estimatedEnd)
    {
        Guid routeId = Guid.NewGuid(), departureAddressId = Guid.NewGuid(), vehicleId = Guid.NewGuid();
        DateTime createdAt = DateTime.Now.ToUniversalTime(), updatedIn = DateTime.Now.ToUniversalTime();
        var status = RouteStatusEnum.PLANNED;
        var totalDistanceKm = 10.2f;

        Action route = () => new Route(routeId, createdAt, updatedIn, estimatedStart, estimatedEnd, totalDistanceKm, status, departureAddressId, vehicleId);

        route.Should().Throw<ArgumentException>()
            .WithMessage("Start date and time not permitted.");
    }
}