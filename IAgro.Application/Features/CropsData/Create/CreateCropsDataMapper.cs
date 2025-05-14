using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.CropsData.Create;

public class CreateCropDataMapper : Profile
{
    public CreateCropDataMapper()
    {
        CreateMap<CreateCropDataRequest, CropData>();
        CreateMap<CropData, CreateCropDataResponse>();
    }
}