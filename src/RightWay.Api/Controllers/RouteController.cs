using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RightWay.Api.Controllers.BaseController;
using RightWay.Application.Request;
using System.ComponentModel.DataAnnotations;

namespace RightWay.Api.Controllers;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class RouteController(IMediator mediator) 
    : BaseApiController(mediator)
{
    [HttpPost("calculate")]
    public async Task<ActionResult> CalculateBestRoute([Required, FromBody] RouteCalculationRequest request)
        => await SendCommand(request);
}