using AutoMapper;
using IAgro.Application.Repositories;
using IAgro.Application.Repositories.CompaniesRepository;
using IAgro.Domain.Models;
using MediatR;

namespace IAgro.Application.Features.Companies.Update;

public class UpdateCompanyHandler(
    ICompaniesRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<UpdateCompanyResponse> Handle(
        UpdateCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request);

        companiesRepository.Update(company);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateCompanyResponse>(company);
    }
}