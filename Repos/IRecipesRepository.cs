using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Recipes;

namespace SmartRecipes.Server.Repos;
public interface IRecipesRepository
{
    public RecipeListDto<T> GetAllRecipes<T>() where T : RecipeDataBase;
    public RecipeListDto<T> SearchRecipesPaged<T>(int itemsPerPage, int currentPage, string searchToken) where T : RecipeDataBase;
    public RecipeListDto<T> SearchFirstRecipes<T>(int itemsCount, string searchToken) where T : RecipeDataBase;
    public RecipeListDto<T> GetRecipesByID<T>(IEnumerable<string> IDs) where T : RecipeDataBase;
    public RecipeDto<RecipeData> GetRecipeByID(string id);
}

