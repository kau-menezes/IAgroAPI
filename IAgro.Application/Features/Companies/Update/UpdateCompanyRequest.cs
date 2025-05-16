using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.Companies.Update;

public sealed record UpdateCompanyRequest(
    string? Name,
    string? CNPJ,
    string? Country,
    string? TimeZone,
    List<CropData>? CropsData
) : IRequest<UpdateCompanyResponse>;