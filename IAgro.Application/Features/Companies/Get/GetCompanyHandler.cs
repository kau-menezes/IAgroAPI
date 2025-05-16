using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CompaniesRepository;
using MediatR;

namespace IAgro.Application.Features.Companies.Get;


public class GetCompanyHandler(
    ICompaniesRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<GetCompanyRequest, GetCompanyResponse>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<GetCompanyResponse> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = await companiesRepository.Get(request.Id, cancellationToken);

        return mapper.Map<GetCompanyResponse>(company);
    }
}