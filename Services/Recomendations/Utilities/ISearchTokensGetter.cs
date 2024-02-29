using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.Services.Recomendations.Utilities;

public interface ISearchTokensGetter
{
    public IEnumerable<string> GetTokens(Recipe? recipe);
}
