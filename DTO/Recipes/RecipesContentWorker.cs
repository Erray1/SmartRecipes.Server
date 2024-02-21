using SmartRecipes.Server.DataContext.Recipes.Models;

namespace SmartRecipes.Server.DTO.Recipes;

public static class RecipesContentWorker
{
    public static RecipeDataBase ToDTO(Recipe recipe, RecipeDTOTypes dtoType)
    {
        switch (dtoType)
        {
            case RecipeDTOTypes.Shortened:
                return new RecipeShortenedData
                {
                    ID = recipe.ID,
                    Image = recipe.RecipeImage.ImageData,
                    Name = recipe.RecipeName
                };
            case RecipeDTOTypes.Preview:
                return new RecipePreviewData
                {
                    ID = recipe.ID,
                    Image = recipe.RecipeImage.ImageData,
                    IngedientsCount = recipe.Ingredients.Count(),
                    Name = recipe.RecipeName,
                    Rating = recipe.Rating,
                    TimeToCook = recipe.TimeToCook
                };
            case RecipeDTOTypes.Full:
                return new RecipeData
                {
                    ID = recipe.ID,
                    Image = recipe.RecipeImage.ImageData,
                    IngedientsCount = recipe.Ingredients.Count(),
                    Name = recipe.RecipeName,
                    Rating = recipe.Rating,
                    TimeToCook = recipe.TimeToCook,
                    Description = recipe.RecipeDescription,
                    Ingredients = recipe.Ingredients.Select(x => new IngredientAmountData
                    {
                        ID = x.ID,
                        Name = x.IngredientName,
                        Amount = x.IngredientAmounts.Single(e => e.RecipeID == recipe.ID).Amount
                    }).ToList()
                };
        }
        return null!;
    }
}

public enum RecipeDTOTypes
{
    Shortened,
    Preview,
    Full
}