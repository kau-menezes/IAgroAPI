using MediatR;

namespace IAgro.Application.Features.Companies.Create;

public sealed record CreateCompanyRequest(
    string Name
) : IRequest<CreateCompanyResponse>;