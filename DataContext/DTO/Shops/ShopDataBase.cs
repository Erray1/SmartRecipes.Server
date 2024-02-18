using SmartRecipes.Server.DataContext.DTO.Shops;

namespace SmartRecipes.Server.DataContext.DTO.Shops.Abstract;

public abstract class ShopDataBase
{
    public int TimeToTravelSeconds { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<IngredientPriceData> Ingredients { get; set; }
}
