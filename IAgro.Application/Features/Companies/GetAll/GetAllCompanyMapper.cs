namespace IAgro.Application.Features.Companies.GetAll;
using IAgro.Domain.Models;
using AutoMapper;

public class GetAllCompanyMapper : Profile
{
    public GetAllCompanyMapper()
    {
        CreateMap<GetAllCompanyRequest, Company>();
        CreateMap<Company, GetAllCompanyResponse>();
    }
}