using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.Companies.Update;

public class UpdateCompanyMapper : Profile
{
    public UpdateCompanyMapper()
    {
        CreateMap<UpdateCompanyRequest, Company>();
        CreateMap<Company, UpdateCompanyResponse>();
    }
}