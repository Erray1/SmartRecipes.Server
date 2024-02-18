using System.ComponentModel.DataAnnotations.Schema;

namespace SmartRecipes.Server.DataContext.Recipes.Models;

public sealed class Image
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; }
    public Recipe Recipe { get; set; }
    public byte[] ImageData { get; set; }
    public string ImageName { get; set; }
}