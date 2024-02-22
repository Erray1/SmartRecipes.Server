using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Users;
using SmartRecipes.Server.DataContext.Users.Models;

namespace SmartRecipes.Server.DataContext.Extensions;

public static partial class ServicesExtensions
{
    public static IServiceCollection AddRecipesContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RecipesContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("WebApiPostgreSQLDatabase"));
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });
        return services;
    }
    public static IServiceCollection AddUsersContext(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<UsersContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("WebApiPostgreSQLDatabase"));
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });
        services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UsersContext>();
        return services;
    }
}
