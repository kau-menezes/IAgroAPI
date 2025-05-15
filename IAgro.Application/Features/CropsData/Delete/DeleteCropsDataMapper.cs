using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.CropsData.Delete;

public class DeleteCropDataMapper : Profile
{
    public DeleteCropDataMapper()
    {
        CreateMap<DeleteCropDataRequest, CropData>();
        CreateMap<CropData, DeleteCropDataResponse>();
    }
}