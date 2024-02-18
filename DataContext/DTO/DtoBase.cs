namespace SmartRecipes.Server.DataContext.DTO.Abstract;

public abstract class DtoBase
{
    public bool IsSuccesful { get; set; }
    public List<string> Errors { get; set; } = new();
}