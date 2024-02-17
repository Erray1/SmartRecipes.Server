namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Recipe
{
    public string RecipeID { get; set; }
    public Image RecipeImage { get; set; } = null!;
    public string RecipeName { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public string RecipeDescription { get; set; } = null!;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public Dictionary<string, int> Rating { get; set; } = new() { { "likes", 0 }, { "dislikes", 0 } };
    public float TimeToCook { get; set; }
}
