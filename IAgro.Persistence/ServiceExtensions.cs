using IAgro.Application.Repositories;
using IAgro.Application.Repositories.CompaniesRepository;
using IAgro.Application.Repositories.CropsRepository;
using IAgro.Application.Repositories.DevicesRepository;
using IAgro.Application.Repositories.FieldsRepository;
using IAgro.Application.Repositories.UsersRepository;
using IAgro.Persistence.Config;
using IAgro.Persistence.Context;
using IAgro.Persistence.Repositories;
using IAgro.Persistence.Repositories.Companies;
using IAgro.Persistence.Repositories.Crops;
using IAgro.Persistence.Repositories.Devices;
using IAgro.Persistence.Repositories.Fields;
using IAgro.Persistence.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IAgro.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<IAgroContext>(opt => opt.UseNpgsql(connection,
            o => o.UseNetTopologySuite()));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<ICropDiseasesRepository, CropDiseasesRepository>();
        services.AddScoped<IDevicesRepository, DevicesRepository>();
        services.AddScoped<IFieldsRepository, FieldsRepository>();
        services.AddScoped<IFieldScansRepository, FieldScansRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
    }
}