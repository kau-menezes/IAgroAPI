using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CropsDataRepository;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.CropsData.Update;

public class UpdateCropDataHandler(
    ICropsDataRepository cropsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateCropDataRequest, UpdateCropDataResponse>
{
    private readonly ICropsDataRepository cropsRepository = cropsRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<UpdateCropDataResponse> Handle(UpdateCropDataRequest request, CancellationToken cancellationToken)
    {
        var cropData = mapper.Map<CropData>(request);

        cropsRepository.Update(cropData);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateCropDataResponse>(cropData);
    }
}