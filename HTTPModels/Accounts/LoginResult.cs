namespace SmartRecipes.Server.HTTPModels.Accounts;

public sealed class LoginResult
{
    public bool IsSuccesful { get; set; }
    public List<string>? Errors { get; set; }
    public string Token { get; set; }
}