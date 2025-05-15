using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.CropsData.Update;

public class UpdateCropDataMapper : Profile
{
    public UpdateCropDataMapper()
    {
        CreateMap<UpdateCropDataRequest, CropData>();
        CreateMap<CropData, UpdateCropDataResponse>();
    }
}