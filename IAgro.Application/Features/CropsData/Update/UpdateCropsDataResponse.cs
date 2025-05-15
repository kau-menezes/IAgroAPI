namespace IAgro.Application.Features.CropsData.Update;

public sealed record UpdateCropDataResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CompanyId,
    List<string> DiseaseCoords
);