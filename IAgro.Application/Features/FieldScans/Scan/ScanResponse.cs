using IAgro.Domain.Models;
using IAgro.Domain.Objects;

namespace IAgro.Application.Features.FieldScans.Scan;

public sealed record ScanResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    DateTime StartedAt,
    Guid DeviceId,
    Guid FieldId,
    List<CropDisease> CropDiseasesFound
);