﻿using System;
using System.Reflection;
using Mapster;
using static System.Net.Mime.MediaTypeNames;

namespace Fiap.TasteEase.Webhost;

public static class Program
{
    public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        var mappersAssemblies = Array.Empty<Assembly>();

        mappersAssemblies = mappersAssemblies.Append(typeof(Infra.DependencyInjection).Assembly).ToArray();
        mappersAssemblies = mappersAssemblies.Append(typeof(Application.DependencyInjection).Assembly).ToArray();

        config.Scan(assemblies: mappersAssemblies);
        config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
        config.Compile();

        services.AddSingleton(config);

        return services;
    }
}