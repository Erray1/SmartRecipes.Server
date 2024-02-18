using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartRecipes.Server.DataContext.Users.Models;

namespace SmartRecipes.Server.DataContext.Users;

public class  UsersContext : IdentityDbContext<User>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }
    public UsersContext()
    {

    }
    private IConfiguration configuration;
    public UsersContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiUsersDatabase"));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
