using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DataContext.Users.Models;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Recomendations.Utilities;

namespace SmartRecipes.Server.Services.Recomendations;

public sealed class RecomendationsMaker
{
    private readonly ISearchable searchEngine;
    private readonly SearchTokensWorker searchTokensWorker;
    public RecomendationsMaker(ISearchable searchEngine, SearchTokensWorker searchTokensWorker)
    {
        this.searchTokensWorker = searchTokensWorker;
        this.searchEngine = searchEngine;
    }
    public IQueryable<Recipe> GetRecomendationsQuery(User user)
    {
        var uniqueTokens = searchTokensWorker.GetUniqueTokensOrdered(RecipesInteractedByUser.GetFromUser(user), SearchProperties.Name);
        var recipesSearched = searchEngine.Search(SearchProperties.Name, uniqueTokens);

        return recipesSearched;
    }
}
