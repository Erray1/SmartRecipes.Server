using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.DataContext.Recipes;

public class RecipesContext : DbContext
{
    public RecipesContext() { }
    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Shop> Shops { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        // Categories

        modelBuilder.Entity<Category>()
            .HasKey(e => e.ID);

        modelBuilder.Entity<Category>()
            .HasMany(e => e.RecipesWhereUsed)
            .WithOne(e => e.Category);

        // Images

        modelBuilder.Entity<Image>()
            .HasKey(e => e.ID);

        // Ingredients

        modelBuilder.Entity<Ingredient>()
            .HasKey(e => e.ID);

        // Shops

        modelBuilder.Entity<Shop>()
            .HasKey();
        modelBuilder.Entity<Shop>()
            .HasMany(e => e.AvailableIngredients)
            .WithMany(e => e.ShopsWhereAvailable);

        // Recipes

        modelBuilder.Entity<Recipe>()
            .HasKey(e => e.RecipeID);

        modelBuilder.Entity<Recipe>()
            .HasOne(e => e.RecipeImage)
            .WithOne(e => e.Recipe);

        modelBuilder.Entity<Recipe>()
            .HasMany(e => e.Ingredients)
            .WithMany(e => e.RecipesWhereUsed);

        modelBuilder.Entity<Recipe>()
            .Property(e => e.Rating)
            .HasConversion(
                v => JsonSerializer.Serialize(v, options),
                s => JsonSerializer.Deserialize<Dictionary<string, int>>(s, options)!,
                ValueComparer.CreateDefault(typeof(Dictionary<string, int>), false)
            );

    }
}
