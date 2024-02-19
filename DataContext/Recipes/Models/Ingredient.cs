using System.ComponentModel.DataAnnotations.Schema;


namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Ingredient : EntityModelBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public string IngredientName { get; set; } = string.Empty;
    public int Price { get; set; }
    public ICollection<Shop> ShopsWhereAvailable { get; set; } = new List<Shop>();
    public ICollection<IngredientPriceForShop> IngredientPrices { get; set; } = new List<IngredientPriceForShop>();
    public ICollection<Recipe> RecipesWhereUsed { get; } = new List<Recipe>();
}
