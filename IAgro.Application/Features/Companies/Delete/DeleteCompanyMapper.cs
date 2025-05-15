using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.Companies.Delete;

public class DeleteCompanyMapper : Profile
{
    public DeleteCompanyMapper()
    {
        CreateMap<DeleteCompanyRequest, Company>();
        CreateMap<Company, DeleteCompanyResponse>();
    }
}