namespace SmartRecipes.Server.DataContext.DTO.Recipes.Abstract;

public abstract class RecipeDataBase
{
    public string ID { get; set; }
    public string Name { get; set; }
    public object Image { get; set; }
}