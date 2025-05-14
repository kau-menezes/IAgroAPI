using MediatR;

namespace IAgro.Application.Features.CropsData.Create;

public sealed record CreateCropDataRequest(
    Guid CompanyId,
    List<string> DiseaseCoords
) : IRequest<CreateCropDataResponse>;