using Microsoft.EntityFrameworkCore;
using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.SearchEngines.Utilities;
using System.Linq.Expressions;
using System.Text;

namespace SmartRecipes.Server.SearchEngines;

public class SimpleStrictSearch : ISearchEngine
{
    private readonly RecipesContext db;

    public SimpleStrictSearch(RecipesContext db)
    {
        this.db = db;
    }

    public IQueryable<Recipe> Search(SearchProperties searchProperty, IEnumerable<string> searchTokens)
    {
        return db.Recipes
            .Where(x => SearchHelper.GetSearchedValues(x, searchProperty)
                .Intersect(searchTokens)
                .Count() >=
                searchTokens
                .Count() / 2)
            .OrderByDescending(x => SearchHelper.GetTokensHitAmount(x, searchProperty, searchTokens));
    }
}
