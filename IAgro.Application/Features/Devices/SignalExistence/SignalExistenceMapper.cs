using IAgro.Domain.Models;
using AutoMapper;

namespace IAgro.Application.Features.Devices.SignalExistence;

public class SignalExistenceMapper : Profile
{
    public SignalExistenceMapper()
    {
        CreateMap<SignalExistenceRequest, Device>();
        CreateMap<Device, SignalExistenceResponse>();
    }
}