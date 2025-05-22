using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Repositories.Fields;

public class FieldsRepository(IAgroContext context)
    : BaseRepository<Field>(context), IFieldsRepository
{
    public Task<List<Field>> GetByCompany(Guid companyId, CancellationToken cancellationToken)
        => context.Set<Field>()
        .Where(f => f.DeletedAt == null)
        .Where(f => f.CompanyId == companyId)
        .ToListAsync(cancellationToken);


}