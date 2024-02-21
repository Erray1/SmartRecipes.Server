using Microsoft.EntityFrameworkCore;
using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.SearchEngines;

public class SimpleSearch : ISearchable
{
    private IQueryable<Recipe> searchByName(DbSet<Recipe> recipes, string strippedSearchField)
    {
        return recipes.Where(x => strippedSearchField.Contains(x.RecipeName));
    }
    public IQueryable<Recipe> Search(DbSet<Recipe> recipes, SearchTypes searchType, string[] searchTokens)
    {
        switch (searchType)
        {
            // Пока реализован только писк по имени
            case SearchTypes.NameAndDescription:
            case SearchTypes.Description:
            case SearchTypes.Name:
                var strippedSearchField = String.Join(" ", searchTokens);
                return searchByName(recipes, strippedSearchField);
                
        }
        throw new ArgumentException("Не введён тип поиска");
    }
}
