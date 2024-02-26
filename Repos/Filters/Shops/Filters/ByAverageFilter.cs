using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;

namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public class ByAverageFilter : IFilterable
{
    private readonly string userAddress;
    public ByAverageFilter(string userAddress)
    {
        this.userAddress = userAddress;
    }
    public IEnumerable<ShopData> Filter(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy)
    {
        throw new NotImplementedException();
    }
}
