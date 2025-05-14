using AutoMapper;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CompaniesRepository;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.Companies.Create;

public class CreateCompanyHandler(
    ICompaniesRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request);

        companiesRepository.Create(company);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateCompanyResponse>(company);
    }
}