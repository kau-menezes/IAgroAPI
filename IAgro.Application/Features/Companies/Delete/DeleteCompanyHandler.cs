using AutoMapper;
using IAgro.Application.Common.Exceptions;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CompaniesRepository;
using IAgro.Domain.Common.Enums;
using IAgro.Domain.Common.Messages;
using IAgro.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IAgro.Application.Features.Companies.Delete;

public class DeleteCompanyHandler(
    ICompaniesRepository companiesRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteCompanyRequest, DeleteCompanyResponse>
{
    private readonly ICompaniesRepository companiesRepository = companiesRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<DeleteCompanyResponse> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request);
        if (await companiesRepository.Exists(company.Id, cancellationToken))
            companiesRepository.Delete(company);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteCompanyResponse>(company);
    }
}