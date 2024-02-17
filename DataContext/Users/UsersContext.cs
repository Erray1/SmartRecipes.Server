using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
}