using GestorQA_GCP.Application.Abstractions.Persistence;
using GestorQA_GCP.Application.Abstractions.Services;
using GestorQA_GCP.Infrastructure.Repositories;
using GestorQA_GCP.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestorQA_GCP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IClock, SystemClock>();
        services.AddScoped(typeof(IRepository<>), typeof(InMemoryRepository<>));

        return services;
    }
}