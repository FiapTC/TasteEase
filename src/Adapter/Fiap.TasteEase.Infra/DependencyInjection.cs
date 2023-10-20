using Fiap.TasteEase.Application.Ports;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate;
using Fiap.TasteEase.Domain.Aggregates.OrderAggregate.ValueObjects;
using Fiap.TasteEase.Domain.Ports;
using Fiap.TasteEase.Infra.Context;
using Fiap.TasteEase.Infra.Models;
using Fiap.TasteEase.Infra.Repository;
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
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}