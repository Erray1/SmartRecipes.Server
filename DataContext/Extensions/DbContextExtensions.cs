using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Users;
using SmartRecipes.Server.DataContext.Users.Models;

namespace SmartRecipes.Server.DataContext.Extensions;

public static class DataContextExtensions
{
    public static IServiceCollection AddRecipesContext(this IServiceCollection services)
    {
        services.AddDbContext<RecipesContext>(options =>
        {
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });
        return services;
    }
    public static IServiceCollection AddUsersContext(this IServiceCollection services)
    {
        
        services.AddDbContext<UsersContext>(options => {
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });
        services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UsersContext>();
        return services;
    }
}
