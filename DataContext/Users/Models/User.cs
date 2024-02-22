using Microsoft.AspNetCore.Identity;


namespace SmartRecipes.Server.DataContext.Users.Models;

public class User : IdentityUser
{
    public ICollection<string> VisitedRecipesIDs { get; } = new List<string>();
    public ICollection<string> FavouriteRecipesIDs { get; } = new List<string>();
    public ICollection<string> LikedRecipesIDs { get; } = new List<string>();
    public ICollection<string> DislikedRecipesIDs { get; } = new List<string>();
}