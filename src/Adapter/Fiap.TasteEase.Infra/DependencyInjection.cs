using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.TasteEase.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEfCoreConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContextAdapter>();

            return services;
        }
    }
}