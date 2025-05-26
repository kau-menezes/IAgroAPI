using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.FieldScans.Scan;

public class ScanMapper : Profile
{
    public ScanMapper()
    {
        CreateMap<ScanRequest, FieldScan>();
        CreateMap<FieldScan, ScanResponse>();
    }
}
