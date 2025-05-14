namespace IAgro.Application.Features.CropsData.Create;

public sealed record CreateCropDataResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);