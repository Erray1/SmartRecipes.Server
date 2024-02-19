using SmartRecipes.Server.DTO.Shops;

namespace SmartRecipes.Server.Repos;

public interface IShopsRepository
{
    public Task<ShopsDto> GetShopsDataFor(string recipeID, IEnumerable<string> notPresentIngredientIds, string? shopsFilter, string userName);
}