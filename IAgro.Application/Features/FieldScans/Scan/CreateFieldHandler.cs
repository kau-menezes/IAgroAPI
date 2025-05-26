using AutoMapper;
using IAgro.Application.Common.Exceptions;
using IAgro.Application.Common.Session;
using IAgro.Application.Features.Fields.Create;
using IAgro.Application.Repositories;
using IAgro.Application.Repositories.DevicesRepository;
using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Domain.Common.Messages;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.FieldScans.Scan;

public class ScanHandler(
    IFieldScansRepository fieldScanRepository,
    IDevicesRepository deviceRepository,
    IFieldsRepository fieldRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<ScanRequest, ScanResponse>
{

    public async Task<ScanResponse> Handle(
        ScanRequest request, CancellationToken cancellationToken)
    {
        requestSession.GetSessionOrThrow();

        var device = await deviceRepository.Get(request.DeviceId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Device);

        var field = await fieldRepository.Get(request.FieldId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Field);

        var newScan = mapper.Map<FieldScan>(request);

        foreach (var disease in newScan.CropDiseases)
        {
            disease.FieldScan = newScan;
        }

        fieldScanRepository.Create(newScan);
        await unitOfWork.Save(cancellationToken);

        Console.WriteLine(newScan);
        Console.WriteLine(newScan.CropDiseases);

        return mapper.Map<ScanResponse>(newScan);
    }
}