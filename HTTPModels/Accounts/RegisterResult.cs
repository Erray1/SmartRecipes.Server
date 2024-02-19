namespace SmartRecipes.Server.HTTPModels.Accounts;

public sealed class RegisterResult
{
    public bool IsSuccesful { get; set; }
    public List<string>? Errors { get; set; }
}