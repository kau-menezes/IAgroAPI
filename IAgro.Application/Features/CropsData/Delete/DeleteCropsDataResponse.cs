namespace IAgro.Application.Features.CropsData.Delete;

public sealed record DeleteCropDataResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid CompanyId,
    List<string> DiseaseCoords
);