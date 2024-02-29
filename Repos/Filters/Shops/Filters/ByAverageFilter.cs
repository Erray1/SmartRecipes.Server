using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Filters.Shops.Filters.Utilities;

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
        //var shops = ingredientsToBuy
        //    .Select(ingrId => query
        //        .Where(s => s.AvailableIngredients
        //            .Select(ingr => ingr.ID)
        //            .Contains(ingrId))
        //        .Select(s => new
        //        {
        //            ShopID = s.ID,
        //            IngredientPrice = s.IngredientPrices.First(i => i.IngredientID == ingrId),
        //            Address = s.Address
        //        })
        //        .OrderBy(shop => shop.IngredientPrice)
        //        .ThenBy(shop => RandomPathTimeCalculator.GetPathTimeInMunutes(userAddress, shop.Address))
        //        .First())
        //    .GroupBy(x => x.ShopID)
        //    .Select(x => new ShopData
        //    {
        //        Ingredients = x.Select(e => new IngredientPriceData
        //        {
        //            Name = e.IngredientPrice.
        //        })
        //    })

        throw new NotImplementedException();
            

    }
}


