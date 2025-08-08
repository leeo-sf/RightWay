using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RightWay.Api.Controllers.BaseController;
using RightWay.Application.Dto;
using RightWay.Application.Request.Order;
using RightWay.Application.Response;
using System.ComponentModel.DataAnnotations;

namespace RightWay.Api.Controllers;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class OrderController(IMediator mediator)
    : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<ActionResult<StatusOperationResponse>> RegisterConfirmedOrder([Required, FromBody] OrderConfirmedRequest request)
        => await SendCommand(request);

    [HttpPost("pending-separation")]
    public async Task<ActionResult<List<OrderDto>>> OrdersAwaitingSeparationAsync()
        => await SendCommand(new OrdersAwaitingSeparationRequest());
}
