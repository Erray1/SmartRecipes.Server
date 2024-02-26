﻿using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Filters.Shops.Filters;

namespace SmartRecipes.Server.Repos.Filters.Shops.LINQExtensions;

public static partial class LINQExtensionsShops
{
    public static IEnumerable<ShopData> ToShopDataWithFilter(this IQueryable<Shop> shopQuery, IEnumerable<string> ingredientsToBuy, ShopsFilterOptions options)
    {
        return ShopsFilters.CreateNew(options).Filter(shopQuery, ingredientsToBuy);
    }
    
}
