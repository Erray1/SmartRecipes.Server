namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Image
{
    public string ID { get; set; } = string.Empty;
    public string IngredientID { get; set; }
    public Recipe Recipe { get; set; }

    public object ImageData { get; set; } = default!; // Понять, какой тип данных хранить
}