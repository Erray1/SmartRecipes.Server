using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Calculators;

namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public class ByBestPriceFilter : IFilterable
{
    public IEnumerable<ShopData> Filter(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy)
    {
        throw new NotImplementedException();
    }
}
