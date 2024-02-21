using SmartRecipes.Server.DTO.Shops;

namespace SmartRecipes.Server.Repos;

public interface IShopsRepository
{
    public Task<ShopsDto> GetShopsDataForAsync(string recipeID, IEnumerable<string> notPresentIngredientIds, string? shopsFilter, string userAddress);
}