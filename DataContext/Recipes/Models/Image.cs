using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Image : EntityModelBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public byte[] ImageData { get; set; }
    public string ImageName { get; set; }
    public string ImageURL { get; set; }
}