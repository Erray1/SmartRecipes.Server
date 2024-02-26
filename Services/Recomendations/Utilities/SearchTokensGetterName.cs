using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.Services.Recomendations.Utilities;

public class SearchTokensGetterByName : ISearchTokensGetter
{
    public IEnumerable<string> GetTokens(Recipe recipe)
    {
        return recipe.RecipeName.Split(' ');
    }
}