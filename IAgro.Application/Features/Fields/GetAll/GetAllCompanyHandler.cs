using AutoMapper;
using MediatR;
using IAgro.Application.Repositories.CompaniesRepository;
using IAgro.Application.Common.Session;
using IAgro.Application.Common.Exceptions;
using IAgro.Domain.Common.Messages;

namespace IAgro.Application.Features.Companies.GetAll;

public class GetAllCompaniesHandler(
    ICompaniesRepository companiesRepository,
    IRequestSession requestSession,
    IMapper mapper
) : IRequestHandler<GetAllCompaniesRequest, List<GetAllCompaniesResponse>>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IRequestSession requestSession = requestSession;
    private readonly IMapper mapper = mapper;

    public async Task<List<GetAllCompaniesResponse>> Handle(
        GetAllCompaniesRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if(!session.IsAdmin)
            throw new ForbiddenException(ExceptionMessages.Forbidden.Admin);

        var companies = await companiesRepository.GetAll(cancellationToken);

        return mapper.Map<List<GetAllCompaniesResponse>>(companies);
    }
}