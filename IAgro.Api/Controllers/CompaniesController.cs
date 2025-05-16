using IAgro.API.Enums;
using IAgro.Application.Features.Companies.Create;
using IAgro.Application.Features.Companies.Delete;
using IAgro.Application.Features.Companies.Get;
using IAgro.Application.Features.Companies.GetAll;
using IAgro.Application.Features.Companies.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAgro.API.Controllers;

[ApiController]
[Route(APIRoutes.Companies)]
public class CompaniesController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateCompanyResponse>> Create(
        CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Companies, response);
    }

    [HttpPatch]
    public async Task<ActionResult<UpdateCompanyResponse>> Update(
        UpdateCompanyRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Accepted(APIRoutes.Companies, response);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteCompanyResponse>> Delete(
        DeleteCompanyRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Accepted(APIRoutes.Companies, response);
    }

    [HttpGet]
    public async Task<ActionResult<GetCompanyResponse>> Get(
        GetCompanyRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetAllCompanyResponse>> GetAll(
        GetAllCompanyRequest request, CancellationToken cancellationToken
    ) {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}