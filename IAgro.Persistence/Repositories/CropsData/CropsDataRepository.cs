using IAgro.Application.Repository.CropsDataRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;

namespace IAgro.Persistence.Repositories.CropsData;

public class CropsDataRepository(
    IAgroContext context
) : BaseRepository<CropData>(context), ICropsDataRepository {}