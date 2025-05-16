namespace IAgro.Application.Features.Companies.GetAll;

using IAgro.Application.Features.Companies.Get;

public sealed record GetAllCompanyResponse(
    List<GetCompanyResponse> Companies
);