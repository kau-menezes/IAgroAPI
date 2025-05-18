using IAgro.Application.Repositories.CompaniesRepository;
using IAgro.Domain.Models;
using IAgro.Persistence.Context;

namespace IAgro.Persistence.Repositories.Companies;

public class CompaniesRepository(
    IAgroContext context
) : BaseRepository<Company>(context), ICompaniesRepository;