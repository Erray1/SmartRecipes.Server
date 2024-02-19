using SmartRecipes.Server.DTO;

namespace SmartRecipes.Server.DTO.Recipes;



public class RecipeListDto<T> : DtoBase where T : RecipeDataBase
{
    public IEnumerable<T> Content { get; set; }
}

public class RecipeDto<T> : DtoBase where T : RecipeDataBase
{
    public T Content { get; set; }
}


