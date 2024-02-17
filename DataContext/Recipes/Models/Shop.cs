namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Shop
{
    public string ID { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<Ingredient> AvailableIngredients { get; set; } = new List<Ingredient>();
