namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Ingredient
{
    public string ID { get; set; } = string.Empty;
    public string IngredientName { get; set; } = string.Empty;
    public ICollection<Shop> ShopsWhereAvailable { get; } = new List<Shop>();
    public ICollection<Recipe> RecipesWhereUsed { get; } = new List<Recipe>();
    public Image IngredientImage { get; set; } = null!;
}
