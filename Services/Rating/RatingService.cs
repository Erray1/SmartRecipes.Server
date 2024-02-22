using Microsoft.AspNetCore.Identity;
using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DataContext.Users.Models;
using SmartRecipes.Server.HTTPModels.Rating;

namespace SmartRecipes.Server.Services.Rating;

public class RatingService
{
    private readonly RecipesContext db;
    private readonly UserManager<User> userManager;
    public RatingService(RecipesContext db, UserManager<User> userManager)
    {
        this.db = db;
        this.userManager = userManager;
    }
    public async Task<(int, RatingResult)> RateAsync(string recipeId, string? userId, RatingModel model)
    {
        if (userId is null) {
            return (StatusCodes.Status511NetworkAuthenticationRequired, new()
            {
                IsSuccesful = false,
                Errors = new() { "Пользователь не авторизован" }
            });
        }

        Recipe? recipeFound = await db.Recipes.FindAsync(recipeId);
        User userFound = (await userManager.FindByIdAsync(userId))!;
        if (recipeFound is null)
        {
            return (StatusCodes.Status404NotFound, new()
            {
                IsSuccesful = false,
                Errors = new() { $"Рецепт с ID {recipeId} не найден"}
            });
        }

        if (model.Type == "like" && userFound.LikedRecipesIDs.Contains(recipeId) && model.IsPositive ||
            model.Type == "dislike" && userFound.DislikedRecipesIDs.Contains(recipeId) && model.IsPositive ||
            model.Type == "like" && !userFound.LikedRecipesIDs.Contains(recipeId) && !model.IsPositive ||
            model.Type == "dislike" && !userFound.DislikedRecipesIDs.Contains(recipeId) && !model.IsPositive)
        {
            return (StatusCodes.Status400BadRequest, new()
            {
                IsSuccesful = false,
                Errors = new() { String.Format("Оценка {0} {1}", model.Type, model.IsPositive ? "уже выставлена" : "не может быть снята")}
            });
        }

        switch (model.Type)
        {
            case "like":
                userFound.LikedRecipesIDs.Add(recipeId);
                recipeFound.Rating["likes"]++;
                break;
            case "dislike":
                userFound.LikedRecipesIDs.Add(recipeId);
                recipeFound.Rating["dislikes"]++;
                break;
        }

        int affectedRecipe = await db.SaveChangesAsync();
        bool affectedUser = (await userManager.UpdateAsync(userFound)).Succeeded;

        if (!affectedUser || affectedRecipe == 0)
        {
            return (StatusCodes.Status500InternalServerError, new()
            {
                IsSuccesful = false,
                Errors = new() { "Ошибка обновления" }
            });
        }

        return (StatusCodes.Status204NoContent, new()
        {
            IsSuccesful = true
        });
    }
}