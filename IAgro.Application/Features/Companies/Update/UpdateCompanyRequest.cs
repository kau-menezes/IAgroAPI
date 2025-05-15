using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.Companies.Update;

public sealed record UpdateCompanyRequest(
    string? Name,
    List<CropData>? CropsData
) : IRequest<UpdateCompanyResponse>;