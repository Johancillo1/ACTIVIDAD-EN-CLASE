using Consultoria.Application.Interfaces;
using Consultoria.Infrastructure.Persistence;
using Consultoria.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consultoria.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' no configurada.");

        // Versión fija (MariaDB del scaffold). Evita AutoDetect, que exige MySQL al arrancar DI.
        var serverVersion = ServerVersion.Parse("10.4.32-mariadb");

        services.AddDbContext<ConsultoriaDbContext>(options =>
            options.UseMySql(connectionString, serverVersion));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
