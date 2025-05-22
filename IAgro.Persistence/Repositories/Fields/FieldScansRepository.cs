using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IAgro.Persistence.Repositories.Fields;

public class FieldScansRepository(IAgroContext context)
    : BaseRepository<FieldScan>(context), IFieldScansRepository
{
    public Task<FieldScan?> LastScan(Guid fieldId, CancellationToken cancellationToken)
        => context.Set<FieldScan>()
            .Where(fs => fs.DeletedAt == null && fs.FieldId == fieldId)
            .OrderByDescending(fs => fs.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
}
