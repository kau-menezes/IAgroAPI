using AutoMapper;
using IAgro.Application.Common.Exceptions;
using IAgro.Application.Common.Session;
using IAgro.Application.Repositories;
using IAgro.Application.Repositories.DevicesRepository;
using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Domain.Common.Messages;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.FieldScans.Scan;

public class ScanHandler(
    IFieldScansRepository fieldScanRepository,
    // IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ScanRequest, ScanResponse>
{
    public async Task<ScanResponse> Handle(
        ScanRequest request, CancellationToken cancellationToken)
    {
        // requestSession.GetSessionOrThrow();

        var fieldScan = mapper.Map<FieldScan>(request);
        var cropDiseases = request.CropDiseasesFound.Select(x => new CropDisease()
        {
            Disease = x.Disease,
            DetectedAt = x.DetectedAt,
            LocationPoint = x.LocationPoint,   
            FieldScan = fieldScan,
            FieldScanId = fieldScan.Id,
        });

        fieldScan.CropDiseases.AddRange(cropDiseases);
        fieldScanRepository.Create(fieldScan);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<ScanResponse>(fieldScan);
    }
}