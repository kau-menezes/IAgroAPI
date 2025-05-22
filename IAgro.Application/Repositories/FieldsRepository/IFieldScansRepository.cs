using IAgro.Domain.Models;

namespace IAgro.Application.Repositories.FieldsRepository;

public interface IFieldScansRepository : IBaseRepository<FieldScan>
{
    public Task<FieldScan?> LastScan(Guid fieldId, CancellationToken cancellationToken);
}