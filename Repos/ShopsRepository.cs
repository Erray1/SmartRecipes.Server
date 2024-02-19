using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DataContext.Users;
using SmartRecipes.Server.DTO.Shops;
using SmartRecipes.Server.Repos.Calculators;
using SmartRecipes.Server.Repos.Filters.Shops.Filters;
using SmartRecipes.Server.Repos.Filters.Shops.LINQExtensions;

namespace SmartRecipes.Server.Repos;

public sealed class ShopsRepository : IShopsRepository
{
    private readonly RecipesContext db;
    private readonly UsersContext usersDb;
    public ShopsRepository(RecipesContext db, UsersContext userDb)
    {
        this.db = db;
        this.usersDb = userDb;
    }
    public async Task<ShopsDto> GetShopsDataFor(string recipeID, IEnumerable<string> notPresentIngredientIds, string? shopsFilter, string userName)
    {
        if (notPresentIngredientIds.Count() == 0)
        {
            return new()
            {
                IsSuccesful = true,
                Errors = new() { "У вас и так всё есть" },
                Content = new()
            };
        }

        string? userAddress = (await usersDb.Users.FindAsync(userName))?.Address;

        if (userAddress is null)
        {
            return new()
            {
                IsSuccesful = false,
                Errors = new() { "Не найден пользователь с данным именем" },
                Content = new()
            };
        }

        Recipe? recipeFound = await db.Recipes.FindAsync(recipeID);
        if (recipeFound is null) {
            return new()
            {
                IsSuccesful = false,
                Errors = new() { "Не найден рецепт с данным ID" },
                Content = new()
            };
        }

        var shopData = db.Shops
            .Where(e => e.AvailableIngredients
                .Select(e => e.ID)
                .Union(notPresentIngredientIds)
                .Count() != 0)
             .ToShopDataWithFilter(notPresentIngredientIds!, ShopsFilters.GetFromString(new ShopsFilterOptions() { Filter = shopsFilter, UserAddress = userAddress}))
             .ToList();
             
        return new()
        {
            IsSuccesful = true,
            Content = shopData,
            FinalPrice = PriceOfIngredientsCalculator.Calculate(shopData)
        };
        
    }
}
