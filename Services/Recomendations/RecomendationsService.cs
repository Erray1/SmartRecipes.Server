using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRecipes.Server.DataContext.Recipes;
using SmartRecipes.Server.DataContext.Recipes.Models;
using SmartRecipes.Server.DataContext.Users.Models;
using SmartRecipes.Server.DTO.Recipes;
using SmartRecipes.Server.Services.Recomendations.Utilities;

namespace SmartRecipes.Server.Services.Recomendations;

public sealed class RecomendationsService
{
    private readonly UserManager<User> userManager;
    private readonly RecomendationsMaker maker;

    public RecomendationsService(RecomendationsMaker maker, UserManager<User> userManager)
    {
        this.maker = maker;
        this.userManager = userManager;
    }
    public async Task<RecipeListDto<RecipePreviewData>> GetRecomendationsPagedAsync(string userId, int itemsPerPage, int currentPage)
    {
        var user = await userManager.FindByIdAsync(userId);
        var recipesVisited = user!.VisitedRecipesIDs;
        var recipesLiked = user!.LikedRecipesIDs;

        var idsStripped = recipesVisited.Concat(recipesLiked);

        var data = await maker.GetRecomendatonsQuery(idsStripped)
            .Skip((currentPage - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();

        return new()
        {
            IsSuccesful = true,
            Content = data.Select(x => RecipesDTOMapper.ToDTOPreview(x)).ToList()
        };
    }
}
