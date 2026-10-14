using Consultoria.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Consultoria.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        services.AddScoped<IProyectoService, ProyectoService>();
        return services;
    }
}
