namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Category
{
    public string ID { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public ICollection<Recipe> RecipesWhereUsed { get; } = new List<Recipe>();
}
