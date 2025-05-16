using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CompaniesRepository;
using MediatR;

namespace IAgro.Application.Features.Companies.GetAll;

public class GetAllCompanyHandler(
    ICompaniesRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<GetAllCompanyRequest, GetAllCompanyResponse>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<GetAllCompanyResponse> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
    {
        var companies = await companiesRepository.GetAll(cancellationToken);

        return mapper.Map<GetAllCompanyResponse>(companies);
    }
}