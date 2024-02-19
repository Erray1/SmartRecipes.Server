namespace SmartRecipes.Server.DTO.Recipes;
public class RecipeSearchData : RecipeDataBase
{
    public int IngedientsCount { get; set; }
    public float TimeToCook { get; set; }
    public Dictionary<string, int> Rating { get; set; } = new();
}

