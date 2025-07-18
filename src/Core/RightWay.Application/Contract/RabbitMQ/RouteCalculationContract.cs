namespace RightWay.Application.Contract.RabbitMQ;

public record RouteCalculationContract(
    int? GroupOrderLimit, float? TotalRouteDistanceLimitInKm, List<AddressContract> Addresses);