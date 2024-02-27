using SmartRecipes.Server.DTO;
using SmartRecipes.Server.DTO.Recipes;

namespace SmartRecipes.Server.Repos;
public interface IRecipesRepository
{
    public Task<RecipeListDto<RecipePreviewData>> GetPopularRecipesPagedAsync(int itemsPerPage, int currentPage);
    public RecipeListDto<RecipePreviewData> SearchRecipesPaged(int itemsPerPage, int currentPage, string searchToken);
    public RecipeListDto<RecipeShortenedData> SearchFirstRecipes(int itemsCount, string searchToken);
    public Task<RecipeListDto<RecipeShortenedData>> GetRecipesByIDAsync(IEnumerable<string> IDs);
    public Task<RecipeDto<RecipeData>> GetRecipeByIDAsync(string id);
}

