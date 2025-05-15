using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.CropsData.Update;

public sealed record UpdateCropDataRequest(
    Guid? CompanyId,
    Company? Company,
    List<string>? DiseaseCoords
) : IRequest<UpdateCropDataResponse>;