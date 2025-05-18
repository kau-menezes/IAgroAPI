using IAgro.Application.Repositories.CropsRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;

namespace IAgro.Persistence.Repositories.Crops;

public class CropDiseasesRepository(IAgroContext context)
    : BaseRepository<CropDisease>(context), ICropDiseasesRepository;