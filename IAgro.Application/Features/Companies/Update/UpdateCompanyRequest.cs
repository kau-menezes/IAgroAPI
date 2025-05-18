using MediatR;

namespace IAgro.Application.Features.Companies.Update;

public sealed record UpdateCompanyRequest(
    Guid Id,
    string Name,
    string CNPJ,
    string Country
) : IRequest<UpdateCompanyResponse>;