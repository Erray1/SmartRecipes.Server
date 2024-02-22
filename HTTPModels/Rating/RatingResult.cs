namespace SmartRecipes.Server.HTTPModels.Rating;


public sealed class RatingResult
{
    public bool IsSuccesful { get; set; }
    public List<string>? Errors { get; set; }
}

