using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.SearchEngines;

namespace SmartRecipes.Server.Services.Recomendations;

public sealed class RecomendationsMaker
{
    private readonly RecipesContext db;
    private readonly ISearchable searchEngine;
    public RecomendationsMaker(RecipesContext db, ISearchable searchEngine)
    {
        this.searchEngine = searchEngine;
        this.db = db;
    }
    public IQueryable<Recipe> GetRecomendatonsQuery(IEnumerable<string> recipeIds)
    {
        var recipes = recipeIds.Select(x => db.Recipes.Find(x) ?? new Recipe());
        var uniqueTokens = SearchTokensWorker.GetUniqueTokensOrdered(recipes, SearchProperties.Name);
        var recipesSearched = searchEngine.Search(db.Recipes, SearchProperties.Name, uniqueTokens);

        return recipesSearched;
    }
}
