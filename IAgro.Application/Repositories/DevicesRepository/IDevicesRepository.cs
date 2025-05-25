using IAgro.Domain.Models;

namespace IAgro.Application.Repositories.DevicesRepository;

public interface IDevicesRepository : IBaseRepository<Device>
{
    public Task<Device?> GetByCoded(string code, CancellationToken cancellationToken);
}