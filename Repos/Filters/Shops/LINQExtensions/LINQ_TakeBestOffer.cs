﻿using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.Repos.Filters.Shops.Filters;
using SmartRecipes.Server.Services.PathCalculator;
using SmartRecipes.Server.Services.PathCalculator.LINQExtensions;

namespace SmartRecipes.Server.Repos.Filters.Shops.LINQExtensions;

public static partial class LINQExtensionsShops
{
    public static IngredientPriceForShop TakeBestOffer(this IQueryable<IngredientPriceForShop> ingredientsData, ShopsFilterOptions options, IPathFinder pathFinder, Dictionary<string, int> pathTimeStorage)
    {
        //Expression<Func<IngredientPriceForShop, object>> expr = options.FilterString switch
        //{
        //    "price" => 
        //}
        IngredientPriceForShop priceForShop;
        switch (options.FilterString)
        {
            case "transport":
                priceForShop = ingredientsData
                    .OrderBy(x => pathFinder.CalculateAndAccumulateTravelTime(options.UserAddress, x.Shop.Address))
                    .First();
                break;
            case "price":
                priceForShop = ingredientsData
                    .OrderBy(x => x.Price)
                    .AccumulateTravelTime(pathFinder, options.UserAddress)
                    .First();
                break;
            case null:
            case "":
            case "average":
                priceForShop = ingredientsData
                    .OrderBy(x => x.Price)
                    .ThenBy(x => pathFinder.CalculateAndAccumulateTravelTime(options.UserAddress, x.Shop.Address))
                    .First();
                break;
            default:
                priceForShop = ingredientsData
                    .AccumulateTravelTime(pathFinder, options.UserAddress)
                    .First();
                break;
        }
        return priceForShop;
    }
}
