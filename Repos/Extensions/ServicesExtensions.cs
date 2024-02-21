using SmartRecipes.Server.DataContext.Extensions;

namespace SmartRecipes.Server.Repos.Extensions;

public static partial class ServicesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IShopsRepository, ShopsRepository>();
        services.AddScoped<IRecipesRepository, RecipesRepository>();
        return services;
    }
}
