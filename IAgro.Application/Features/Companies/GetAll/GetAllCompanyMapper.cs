namespace IAgro.Application.Features.Companies.GetAll;
using IAgro.Domain.Models;
using AutoMapper;

public class GetAllCompaniesMapper : Profile
{
    public GetAllCompaniesMapper()
    {
        CreateMap<Company, GetAllCompaniesResponse>();
    }
}