using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CropsDataRepository;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.CropsData.Create;

public class CreateCropDataHandler(
    ICropsDataRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateCropDataRequest, CreateCropDataResponse>
{
    private readonly ICropsDataRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<CreateCropDataResponse> Handle(CreateCropDataRequest request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<CropData>(request);

        companiesRepository.Create(company);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateCropDataResponse>(company);
    }
}