using MediatR;

namespace RightWay.Application.Request;

public record RouteCalculationRequest(int? GroupOrderLimit, float? TotalRouteDistanceLimitInKm, List<AddressRequest> Addresses) : IRequest<Result>;