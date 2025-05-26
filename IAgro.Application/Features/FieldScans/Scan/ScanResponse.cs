using IAgro.Domain.Models;
using IAgro.Domain.Objects;

namespace IAgro.Application.Features.FieldScans.Scan;

public sealed record ScanResponse(
    Guid Id,
    Guid Code,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    Guid FieldId,
    List<CropDisease> CropDiseases
);