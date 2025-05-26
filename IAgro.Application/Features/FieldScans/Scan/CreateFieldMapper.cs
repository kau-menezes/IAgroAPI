using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.FieldScans.Scan;

public class ScanProfile : Profile
{
    public ScanProfile()
    {
        CreateMap<FieldScan, ScanResponse>()
            .ConstructUsing(src => new ScanResponse(
                src.Id,
                src.DeviceId,
                src.CreatedAt,
                src.UpdatedAt,
                src.DeletedAt,
                src.FieldId,
                src.CropDiseases.ToList() 
            ));

        CreateMap<ScanRequest, FieldScan>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.DeviceId, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CropDiseases, opt => opt.MapFrom(src => src.CropDiseases));

        CreateMap<CropDiseasesRequest, CropDisease>();
        CreateMap<FieldScan, ScanResponse>();
    }
}
