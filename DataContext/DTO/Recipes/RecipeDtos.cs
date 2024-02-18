using SmartRecipes.Server.DataContext.DTO.Recipes.Abstract;
using SmartRecipes.Server.DataContext.DTO.Abstract;

namespace SmartRecipes.Server.DataContext.DTO.Recipes;



public class RecipeSearchListDto<T> : DtoBase where T : RecipeDataBase
{
    public IEnumerable<T> Content { get; set; }
}

public class RecipeDto<T> : DtoBase where T : RecipeDataBase
{
    public T Content { get; set; }
}


