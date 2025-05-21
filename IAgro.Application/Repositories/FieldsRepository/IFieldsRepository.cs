using IAgro.Domain.Models;

namespace IAgro.Application.Repositories.FieldsRepository;

public interface IFieldsRepository : IBaseRepository<Field>
{
    Task<List<Field>> GetByCompany(Guid companyId, CancellationToken cancellationToken);
}