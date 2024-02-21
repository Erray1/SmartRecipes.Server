namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class IngredientAmountForRecipe : EntityModelBase
{
    public string IngredientID { get; set; }
    public string RecipeID { get; set; }
    public string Amount { get; set; }
}
