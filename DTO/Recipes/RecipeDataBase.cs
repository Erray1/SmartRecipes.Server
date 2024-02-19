﻿namespace SmartRecipes.Server.DTO.Recipes;

public abstract class RecipeDataBase : DataBase
{
    public string ID { get; set; }
    public string Name { get; set; }
    public object Image { get; set; }
}