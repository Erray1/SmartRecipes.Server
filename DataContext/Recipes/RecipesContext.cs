﻿using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.DataContext.Recipes;

public class RecipesContext : DbContext
{
    public RecipesContext() { }
    private IConfiguration configuration;
    public RecipesContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Shop> Shops { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<IngredientPriceForShop> IngredientPrices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiRecipesDatabase"));

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
        modelBuilder.Entity<Category>()
            .Property(e => e.CategoryName)
            .HasMaxLength(30);
         

        // Images

        modelBuilder.Entity<Image>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Image>()
            .Property(e => e.ImageData)
            .HasColumnType("BLOB")
            //  .HasConversion()
            .IsRequired();

        // Ingredients

        modelBuilder.Entity<Ingredient>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Ingredient>()
            .Property(e => e.IngredientName)
            .HasColumnType("TEXT")
            .HasMaxLength(30);

        // Shops

        modelBuilder.Entity<Shop>()
            .HasKey(e => e.ID);
        modelBuilder.Entity<Shop>()
            .HasMany(e => e.AvailableIngredients)
            .WithMany(e => e.ShopsWhereAvailable)
            .UsingEntity<IngredientPriceForShop>(
                l => l.HasOne<Ingredient>().WithMany(e => e.IngredientPrices).HasForeignKey(e => e.ShopID),
                r => r.HasOne<Shop>().WithMany(e => e.IngredientPrices).HasForeignKey(e => e.IngredientID),
                j => j.Property(e => e.Price).HasDefaultValueSql("Проставьте тип мужики...."));
        modelBuilder.Entity<Shop>()
            .Property(e => e.Name)
            .HasMaxLength(30)
            .HasColumnType("TEXT")
            .IsRequired();
        modelBuilder.Entity<Shop>()
            .Property(e => e.Address)
            .HasMaxLength(100)
            .HasColumnType("TEXT")
            .IsRequired();

        // Recipes

        modelBuilder.Entity<Recipe>()
            .HasKey(e => e.ID);

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
            )
            .IsRequired();
        modelBuilder.Entity<Recipe>()
            .Property(e => e.RecipeName)
            .HasMaxLength(30)
            .IsRequired();
        modelBuilder.Entity<Recipe>()
            .Property(e => e.RecipeDescription)
            .HasMaxLength(6400)
            .IsRequired();

    }
}
