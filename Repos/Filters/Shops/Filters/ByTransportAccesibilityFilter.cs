using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;

namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public class ByTransportAccesibilityFilter : IFilterable
{
    private readonly string userAddress;
    public ByTransportAccesibilityFilter(string userAddress)
    {
        this.userAddress = userAddress;
    }
    public IEnumerable<Tout> Filter<Tout>(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy) where Tout : DataBase
    {
        return Enumerable.Empty<Tout>();
    }
}
