﻿namespace SmartRecipes.Server.DTO.Recipes;

public class RecipeData : RecipeDataBase
{
    public int IngedientsCount { get; set; }
    public float TimeToCook { get; set; }
    public Dictionary<string, int> Rating { get; set; } = new();
    public List<IngredientAmountData> Ingredients { get; set; } = new();
    public string Description { get; set; } = string.Empty;
}
