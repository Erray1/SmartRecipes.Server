namespace SmartRecipes.Server.DataContext.Recipes.Generators;

using SmartRecipes.Server.DataContext.Recipes.Generators.Models;

public interface IDomainDataAdder
{
    public Task<(bool, string?)> AddCategory(CreateCategoryModel model);
    public Task<(bool, string?)> AddIngredient(CreateIngredientModel model);
    public Task<(bool, string?)> AddShop(CreateShopModel model);
    public Task<(bool, string?)> AddRecipe(CreateRecipeModel model);
}
