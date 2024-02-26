using Microsoft.EntityFrameworkCore;
using SmartRecipes.Server.DataContext.Recipes.Models;
using System.Linq.Expressions;
using System.Text;

namespace SmartRecipes.Server.SearchEngines;

public class SimpleSearch : ISearchable
{
    private static IEnumerable<string> getSearchedValues(Recipe recipe, SearchProperties searchPreperty)
    {
        switch (searchPreperty)
        {
            case SearchProperties.Name:
                return recipe.RecipeName.Split(" ");
            case SearchProperties.Description:
                return recipe.RecipeDescription.Split(" ");
            case SearchProperties.NameAndDescription:
                return (recipe.RecipeName + recipe.RecipeDescription).Split(" ");
            default:
                throw new ArgumentException("Неверный searchType");
        };
    }

    private static int getTokensHit(Recipe recipe, SearchProperties searchProperty, IEnumerable<string> searchTokens)
    {
        return getSearchedValues(recipe, searchProperty).Intersect(searchTokens).Count();
    }

    public IQueryable<Recipe> Search(DbSet<Recipe> recipes, SearchProperties searchProperty, IEnumerable<string> searchTokens)
    {
        var a = recipes.Select(x => getSearchedValues(x, searchProperty));
        return recipes
            .Where(x => getSearchedValues(x, searchProperty)
                .Intersect(searchTokens)
                .Count() >=
                searchTokens
                .Count() / 2)
            .OrderByDescending(x => getTokensHit(x, searchProperty, searchTokens));
    }
}
