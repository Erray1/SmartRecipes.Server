using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.SearchEngines;

public interface ISearchEngine
{
    public IQueryable<Recipe> Search(SearchProperties searchProperty,  IEnumerable<string> searchTokens);
}