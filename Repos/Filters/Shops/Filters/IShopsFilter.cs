using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;


namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public interface IShopsFilter
{
    public IEnumerable<ShopData> Filter(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy, ShopsFilterOptions options);
}
