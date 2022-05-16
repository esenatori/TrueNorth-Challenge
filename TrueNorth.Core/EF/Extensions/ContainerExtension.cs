
using Microsoft.Extensions.DependencyInjection;
using TrueNorth.Core.EF.Context;
using TrueNorth.Core.EF.Repositories;

namespace TrueNorth.Core.EF.Extensions
{
    public static class ContainerExtension
    {
        public static IServiceCollection EFRepositories(this IServiceCollection services)
        {
            _ = services
                .AddScoped<AppDb>()
                .AddScoped<ITaskItemRepository, TaskItemRepository>();

            return services;
        }
    }
}