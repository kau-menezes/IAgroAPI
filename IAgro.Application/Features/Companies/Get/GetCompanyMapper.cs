using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.Companies.Get;

public class GetCompanyMapper : Profile
{
    public GetCompanyMapper()
    {
        CreateMap<GetCompanyRequest, Company>();
        CreateMap<Company, GetCompanyResponse>();
    }
}