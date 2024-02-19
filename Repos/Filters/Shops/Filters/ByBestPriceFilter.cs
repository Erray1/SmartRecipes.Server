using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Calculators;

namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public class ByBestPriceFilter : IFilterable
{
    public IEnumerable<Tout> Filter<Tout>(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy) where Tout : DataBase
    {
        return Enumerable.Empty<Tout>();
    }
}
