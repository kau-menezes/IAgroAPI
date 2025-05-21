using IAgro.API.Enums;
using IAgro.Application.Features.Fields.Create;
using IAgro.Application.Features.Fields.Delete;
using IAgro.Application.Features.Fields.Get;
using IAgro.Application.Features.Fields.GetByCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.Fields)]
public class FieldController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateFieldResponse>> Create(
        CreateFieldRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{fieldId}")]
    public async Task<ActionResult<GetFieldResponse>> Get(
        [FromRoute] Guid fieldId, CancellationToken cancellationToken)
    {
        var request = new GetFieldRequest(fieldId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet, Route("company/{companyId}")]
    public async Task<ActionResult<GetFieldByCompanyResponse>> GetByCompany(
        [FromRoute] Guid companyId, CancellationToken cancellationToken)
    {
        var request = new GetFieldByCompanyRequest(companyId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    // [HttpGet]
    // public async Task<ActionResult<GetAllUsersResponse>> GetAll(
    //     CancellationToken cancellationToken)
    // {
    //     var response = await mediator.Send(new GetAllUsersRequest(), cancellationToken);
    //     return Ok(response);
    // }

    // [HttpPatch, Route("{userId}")]
    // public async Task<ActionResult<UpdateUserResponse>> Update(
    //     [FromRoute] Guid userId,
    //     UpdateUserRequestProps props,
    //     CancellationToken cancellationToken
    // )
    // {
    //     var request = new UpdateUserRequest(userId, props);
    //     var response = await mediator.Send(request, cancellationToken);
    //     return Ok(response);
    // }

    [HttpDelete, Route("{fieldId}")]
    public async Task<ActionResult<DeleteFieldResponse>> Delete(
        [FromRoute] Guid fieldId, CancellationToken cancellationToken
    ) {
        var request = new DeleteFieldRequest(fieldId);
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}