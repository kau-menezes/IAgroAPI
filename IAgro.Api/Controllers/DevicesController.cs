using IAgro.API.Enums;
using IAgro.Application.Features.Devices.SignalExistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.Devices)]
public class DeviceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost, Route("signal")]
    public async Task<ActionResult<SignalExistenceResponse>> SignalExistence(
        SignalExistenceRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    
}