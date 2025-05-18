using IAgro.API.Enums;
using IAgro.Application.Features.Users.Create;
using IAgro.Application.Features.Users.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{userId}")]
    public async Task<ActionResult<GetUserResponse>> Get(
        [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest(userId);
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}