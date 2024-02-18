using System.ComponentModel.DataAnnotations.Schema;


namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Ingredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string IngredientName { get; set; } = string.Empty;
    public ICollection<Shop> ShopsWhereAvailable { get; } = new List<Shop>();
    public ICollection<Recipe> RecipesWhereUsed { get; } = new List<Recipe>();
}
