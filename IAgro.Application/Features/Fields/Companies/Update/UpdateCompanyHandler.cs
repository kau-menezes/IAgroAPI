using AutoMapper;
using IAgro.Application.Common.Exceptions;
using IAgro.Application.Repositories;
using IAgro.Application.Repositories.CompaniesRepository;
using IAgro.Domain.Common.Messages;
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
        var company = await companiesRepository.Get(request.CompanyId, cancellationToken)
            ?? throw new NotFoundException(ExceptionMessages.NotFound.Company);

        if (request.Props.Name is string name)
            company.Name = name;
        if (request.Props.CNPJ is string cnpj)
            company.CNPJ = cnpj;
        if (request.Props.Country is string country)
            company.Country = country;

        companiesRepository.Update(company);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateCompanyResponse>(company);
    }
}