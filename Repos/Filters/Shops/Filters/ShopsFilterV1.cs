using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Calculators;
using SmartRecipes.Server.Repos.Filters.Shops.Filters.Utilities;
using SmartRecipes.Server.Repos.Filters.Shops.LINQExtensions;
using SmartRecipes.Server.Services.PathCalculator;

namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public sealed class ShopsFilterV1 : IShopsFilter
{
    private readonly IPathFinder pathFinder;
    public ShopsFilterV1(IPathFinder pathFinder)
    {
        this.pathFinder = pathFinder;
    }
    public IEnumerable<ShopData> Filter(IQueryable<Shop> query, IEnumerable<string> ingredientsToBuy, ShopsFilterOptions options)
    {
        Dictionary<string, int> pathTimeStorage = new();
        return ingredientsToBuy
            .Select(ingrId => query
                .Where(s => s.AvailableIngredients
                    .Select(ingr => ingr.ID)
                    .Contains(ingrId))
                .Select(s => s.IngredientPrices.Where(p => p.IngredientID == ingrId).First())
                .TakeBestOffer(options, pathFinder, pathTimeStorage))
            .GroupBy(x => x.ShopID)
            .Select(x => new ShopData
            {
                Ingredients = x.Select(e => new IngredientPriceData
                {
                    Name = e.Ingredient.IngredientName,
                    Price = e.Price

                }).ToList(),
                Address = x.First().Shop.Address,
                Name = x.First().Shop.Name,
                TimeToTravelMinutes = pathTimeStorage[x.First().Shop.Address]
            });
    }
}
