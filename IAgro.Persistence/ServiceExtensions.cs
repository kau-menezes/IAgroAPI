
using IAgro.Application.Config;
using IAgro.Application.Repository;
using IAgro.Application.Repository.CompaniesRepository;
using IAgro.Application.Repository.CropsDataRepository;
using IAgro.Persistence.Context;
using IAgro.Persistence.Repositories;
using IAgro.Persistence.Repositories.Companies;
using IAgro.Persistence.Repositories.CropsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IAgro.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<IAgroContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<ICropsDataRepository, CropsDataRepository>();
    }
}