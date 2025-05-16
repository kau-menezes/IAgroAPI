namespace IAgro.Application.Features.Companies.GetAll;
using MediatR;

public sealed record GetAllCompanyRequest(
) : IRequest<GetAllCompanyResponse>;