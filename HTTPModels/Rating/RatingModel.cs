using System.ComponentModel.DataAnnotations;

namespace SmartRecipes.Server.HTTPModels.Rating;

public sealed class RatingModel
{
    [AllowedValues("like", "dislike")]
    public string Type { get; set; } 
    public bool IsPositive { get; set; }
}