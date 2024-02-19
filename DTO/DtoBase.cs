namespace SmartRecipes.Server.DTO;

public abstract class DtoBase
{
    public bool IsSuccesful { get; set; }
    public List<string> Errors { get; set; } = new();
}