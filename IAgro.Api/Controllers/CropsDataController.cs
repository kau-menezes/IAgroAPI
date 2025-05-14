using IAgro.API.Enums;
using IAgro.Application.Features.CropsData.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.CropsData)]
public class CropsDataController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateCropDataResponse>> Create(
        CreateCropDataRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.CropsData, response);
    }
}