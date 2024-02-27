using SmartRecipes.Server.DataContext.Recipes;
using System.Reflection;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Recomendations.Utilities;

namespace SmartRecipes.Server.Services.Recomendations;

public class SearchTokensWorker
{
    private readonly RecipesContext db;
    public SearchTokensWorker(RecipesContext db)
    {
        this.db = db;
    }
    public List<string> GetUniqueTokensOrdered(RecipesInteractedByUser recipes, SearchProperties searchProperty)
    {
        ISearchTokensGetter tokensGetter = SearchTokensGetters.CreateNew(searchProperty)!;

        var preferences = calculateTokensPreferencesSorted(recipes, tokensGetter);
        int minimalPreference = calculateMinimalTokensPreference(preferences, true);

        return preferences
            .Where(x => x.Value >= minimalPreference)
            .Select(x => x.Key)
            .ToList();
        
    }

    private Dictionary<string, int> calculateTokensPreferencesSorted(RecipesInteractedByUser recipes, ISearchTokensGetter tokensGetter)
    {
        Dictionary<string, int> recipesPreferences = new();
        throw new NotImplementedException();
	}

    private int calculateMinimalTokensPreference(Dictionary<string, int> preferences, bool isSorted)
    {
        throw new NotImplementedException();
    }
}

