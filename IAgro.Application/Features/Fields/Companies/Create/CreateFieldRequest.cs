using IAgro.Domain.Objects;
using MediatR;

namespace IAgro.Application.Features.Fields.Create;

public sealed record CreateFieldRequest(
    string Nickname,
    string Crop,
    double Area,
    List<LocationPoint> LocationPoints
) : IRequest<CreateFieldResponse>;