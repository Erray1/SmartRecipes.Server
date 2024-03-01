using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.Services.PathCalculator.LINQExtensions;

public static partial class LINQExtensions
{
    public static IQueryable<IngredientPriceForShop> AccumulateTravelTime(this IQueryable<IngredientPriceForShop> prices, IPathFinder pathFinder, string startingPoint)
    {
        foreach (var item in prices) {
            pathFinder.AccumulateTravelTime(startingPoint, item.Shop.Address);
        }
        return prices;
    }
}