using MediatR;

namespace IAgro.Application.Features.CropsData.Delete;

public sealed record DeleteCropDataRequest(
    string Id
) : IRequest<DeleteCropDataResponse>;