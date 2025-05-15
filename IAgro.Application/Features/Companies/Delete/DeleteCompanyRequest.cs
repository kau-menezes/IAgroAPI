using MediatR;

namespace IAgro.Application.Features.Companies.Delete;

public sealed record DeleteCompanyRequest(
    string Id
) : IRequest<DeleteCompanyResponse>;