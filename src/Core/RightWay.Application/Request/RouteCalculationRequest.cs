using MediatR;
using RightWay.Application.Contract;
using RightWay.Application.Response;

namespace RightWay.Application.Request;

public record RouteCalculationRequest(int? GroupOrderLimit, float? TotalRouteDistanceLimitInKm, List<AddressContract> Addresses) 
    : IRequest<Result<StatusOperationResponse>>;