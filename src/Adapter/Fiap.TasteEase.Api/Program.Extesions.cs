using System.Reflection;
using Mapster;

namespace Fiap.TasteEase.Api;

public static class Program
{
    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
    {
        var assemblies = Array.Empty<Assembly>();
        assemblies = assemblies.Append(typeof(Application.UseCases.ClientUseCase.Create).Assembly).ToArray();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        return services;
    }

    public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        var mappersAssemblies = Array.Empty<Assembly>();

        mappersAssemblies = mappersAssemblies.Append(typeof(Infra.DependencyInjection).Assembly).ToArray();

        config.Scan(assemblies: mappersAssemblies);
        config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
        config.Compile();

        services.AddSingleton(config);

       return services;
    }
}
