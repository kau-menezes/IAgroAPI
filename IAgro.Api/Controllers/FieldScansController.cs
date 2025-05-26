using IAgro.API.Enums;
using IAgro.Application.Features.FieldScans.Scan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.FieldScans)]
public class FieldScanController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<ScanResponse>> Scan(
        ScanRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Fields, response);
    }

}