using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CropsDataRepository;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.CropsData.Delete;

public class DeleteCropDataHandler(
    ICropsDataRepository cropsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteCropDataRequest, DeleteCropDataResponse>
{
    private readonly ICropsDataRepository cropsRepository = cropsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<DeleteCropDataResponse> Handle(DeleteCropDataRequest request, CancellationToken cancellationToken)
    {
        var cropData = mapper.Map<CropData>(request);
        if (!await cropsRepository.Exists(cropData.Id, cancellationToken))
            cropsRepository.Delete(cropData);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteCropDataResponse>(cropData);
    }
}