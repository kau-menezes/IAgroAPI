using IAgro.Domain.Models;

namespace IAgro.Application.Features.Companies.Delete;

public sealed record DeleteCompanyResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime DeletedAt,
    string Name,
    List<CropData> CropsData
);