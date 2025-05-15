using IAgro.Domain.Models;

namespace IAgro.Application.Features.Companies.Update;

public sealed record UpdateCompanyResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    List<CropData> CropsData
);