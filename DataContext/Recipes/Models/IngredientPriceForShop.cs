namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class IngredientPriceForShop : EntityModelBase
{
    public string IngredientID { get; set; }
    public string ShopID { get; set; }
    public double Price { get; set; }
}
