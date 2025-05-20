using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.Fields.Create;

public class CreateFieldMapper : Profile
{
    public CreateFieldMapper()
    {
        CreateMap<CreateFieldRequest, Field>();
        CreateMap<Field, CreateFieldResponse>();
    }
}