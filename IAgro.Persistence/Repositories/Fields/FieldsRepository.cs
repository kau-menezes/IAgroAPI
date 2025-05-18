using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;

namespace IAgro.Persistence.Repositories.Fields;

public class FieldsRepository(IAgroContext context)
    : BaseRepository<Field>(context), IFieldsRepository;