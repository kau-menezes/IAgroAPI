using IAgro.API.Enums;
using IAgro.Application.Features.CropsData.Create;
using IAgro.Application.Features.CropsData.Delete;
using IAgro.Application.Features.CropsData.Update;
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

    [HttpPatch]
    public async Task<ActionResult<UpdateCropDataResponse>> Update(
        UpdateCropDataRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Accepted(APIRoutes.CropsData, response);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteCropDataResponse>> Delete(
        DeleteCropDataRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Accepted(APIRoutes.CropsData, response);
    }
}