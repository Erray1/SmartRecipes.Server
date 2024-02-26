using Microsoft.EntityFrameworkCore;
using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.SearchEngines;

public interface ISearchable
{
    public IQueryable<Recipe> Search(DbSet<Recipe> recipes, SearchProperties searchType, IEnumerable<string> searchTokens);
}