using IAgro.API.Enums;
using IAgro.Application.Features.Fields.Create;
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

    // [HttpGet, Route("{userId}")]
    // public async Task<ActionResult<GetUserResponse>> Get(
    //     [FromRoute] Guid userId, CancellationToken cancellationToken)
    // {
    //     var request = new GetUserRequest(userId);
    //     var response = await mediator.Send(request, cancellationToken);
    //     return Ok(response);
    // }

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
    
    // [HttpDelete, Route("{userId}")]
    // public async Task<ActionResult<DeleteUserResponse>> Delete(
    //     [FromRoute] Guid userId, CancellationToken cancellationToken
    // ) {
    //     var request = new DeleteUserRequest(userId);
    //     await mediator.Send(request, cancellationToken);
    //     return NoContent();
    // }
}