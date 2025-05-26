using IAgro.Application.Features.FieldScans.Scan;
using IAgro.Domain.Models;
using IAgro.Domain.Objects;
using MediatR;

namespace IAgro.Application.Features.FieldScans.Scan;

public sealed record ScanRequest(
    Guid DeviceId,
    Guid FieldId,
    List<CropDiseasesRequest> CropDiseases
) : IRequest<ScanResponse>;

public sealed class CropDiseasesRequest
{
    public required string Disease { get; set; }
    public DateTime DetectedAt { get; set; }
    public required LocationPoint LocationPoint { get; set; }
};