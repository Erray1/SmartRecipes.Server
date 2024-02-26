using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Recomendations.Utilities;

namespace SmartRecipes.Server.Services.Recomendations;

public static class SearchTokensWorker
{
    public static List<string> GetUniqueTokensOrdered(IEnumerable<Recipe> recipes, SearchProperties searchProperty)
    {
        var tokensGetter = SearchTokensGetters.CreateNew(searchProperty);
        var tokensPopularityAccumulator = new Dictionary<string, int>();
        for (int i = 0; i < recipes.Count(); i++)
        {
            var tokens = tokensGetter.GetTokens(recipes.ElementAt(i));
            for (int j = 0; j < tokens.Count(); j++)
            {
                if (tokensPopularityAccumulator.TryGetValue(tokens.ElementAt(j), out _))
                {
                    tokensPopularityAccumulator[tokens.ElementAt(j)]++;
                }
                tokensPopularityAccumulator[tokens.ElementAt(j)] = 1;
            }
        }
        return tokensPopularityAccumulator
            .OrderByDescending(x => x.Value)
            .Select(x => x.Key)
            .ToList();
    }
}

