using IAgro.Application.Repositories.DevicesRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;

namespace IAgro.Persistence.Repositories.Devices;

public class DevicesRepository(IAgroContext context)
    : BaseRepository<Device>(context), IDevicesRepository;